using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleRotator : MonoBehaviour
{

    public float rotSpeed = 50f;
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Rotate(0, rotSpeed*Time.deltaTime, 0);
    }
}
