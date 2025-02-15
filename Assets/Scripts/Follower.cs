using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    Transform playerTrans;
    public float smoothSpeed = 0.01f;

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTrans.position, smoothSpeed);
    }


}
