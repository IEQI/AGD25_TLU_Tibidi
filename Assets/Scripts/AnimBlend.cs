using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimBlend : MonoBehaviour
{

    SkinnedMeshRenderer skinMesh;
    float blendValue = 0f;
    float speedChange = 150f;
    bool increase = true;
    
    void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if (increase)
        {
        blendValue = blendValue + Time.deltaTime * speedChange;
            if (blendValue >= 100f)
            {
                increase = false;
            }
        }

        else
        {
            blendValue = blendValue - Time.deltaTime * speedChange;            
            if (blendValue <= 0f)
            {
                increase = true;
            }

        }

        //Debug.Log(blendValue);

        skinMesh.SetBlendShapeWeight(0, blendValue);
    }
}
