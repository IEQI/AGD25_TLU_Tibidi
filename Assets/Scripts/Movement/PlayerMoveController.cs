using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // or TMPro if using TextMeshPro
using TMPro;

public class PlayerMoveController : MonoBehaviour
{
    public InputAction playerTranslate;
    public InputAction playerRotate;

    public float moveSpeed = 50.0f;
    public float rotSpeed = 1.0f;
    Vector2 moveDirection = Vector2.zero;
    float rotateDirection;
    Rigidbody rigidBod;

    private GameUiManager uiManager; // Reference to UI manager

    private void Start()
    {
        rigidBod = GetComponent<Rigidbody>();

        if (PlayerSaveStatus.hasRunOnce == true && GameObject.FindGameObjectWithTag("SpawnPoint") != null) 
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        }

        uiManager = FindObjectOfType<GameUiManager>(); // Auto-find manager in scene

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
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

    private void FixedUpdate()
    {
        moveDirection = playerTranslate.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
        rotateDirection = playerRotate.ReadValue<float>() * rotSpeed;

        rigidBod.AddForce(moveDirection.x, 0, moveDirection.y);
        rigidBod.AddTorque(0, rotateDirection, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable")) 
        {
            if (uiManager != null)
            {
                string objectName = other.gameObject.name;
                uiManager.UpdateDialTexts(objectName);
            }
        }
    }
}
