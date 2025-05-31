using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    Transform playerTrans;
    public float smoothSpeed = 0.01f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, playerTrans.position, smoothSpeed);
        transform.position = Vector3.SmoothDamp(transform.position, playerTrans.position, ref velocity, smoothSpeed);
    }



}
