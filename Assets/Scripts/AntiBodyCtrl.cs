using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiBodyCtrl : MonoBehaviour
{

    Rigidbody rigidBod;
    public float moveSpeed = 40.0f;
    GameObject player;
    Vector3 dirToPlayer;
    public float attractRange = 5f;


    void Start()
    {
        rigidBod = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        dirToPlayer = player.transform.position - transform.position;

        if (dirToPlayer.magnitude < 5f)
        {

            float multip = moveSpeed * Time.deltaTime;
            dirToPlayer.Normalize();
            rigidBod.AddForce(dirToPlayer.x * multip, 0, dirToPlayer.z * multip);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    }
