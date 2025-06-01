using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutButtonVis : MonoBehaviour
{
    void Start()
    {

        if (PlayerSaveStatus.hasRunOnce == true)
        {
            gameObject.SetActive(false);

        }

    }

    void Update()
    {
        
    }
}
