using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    public InputAction playerTranslate;
    public InputAction playerRotate;

    public float moveSpeed = 1.0f;
    public float rotSpeed = 1.0f;
    Vector2 moveDirection = Vector2.zero;
    float rotateDirection;
    Rigidbody rigidBod;

    private void Start()
    {
        rigidBod = GetComponentInChildren<Rigidbody>();

        
        // If player comes from level 2 then spawn next to the teleporter
        if (PlayerSaveStatus.hasRunOnce == true && GameObject.FindGameObjectWithTag("SpawnPoint") != null) 
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;

        }

    }

    private void OnEnable()
    {
        playerTranslate.Enable();
        playerRotate.Enable();
    }

    private void OnDisable()
    {
        playerTranslate.Disable();
        playerRotate.Disable();
    }


    void Update()
    {
        moveDirection = playerTranslate.ReadValue<Vector2>() * moveSpeed;
        rotateDirection = playerRotate.ReadValue<float>() * rotSpeed;
    }

    private void FixedUpdate()
    {
        rigidBod.AddForce (moveDirection.x, 0, moveDirection.y);
        rigidBod.AddTorque (0, rotateDirection, 0);
    }
}
