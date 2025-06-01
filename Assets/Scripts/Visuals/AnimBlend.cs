using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimBlend : MonoBehaviour
{

    SkinnedMeshRenderer skinMesh;
    float blendValue = 0f;
    float endBlend = 0f;
    public float blendVar = 0.2f;
    public float blendSpeed = 0.7f;
    bool increase = true;
    
    void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
        blendSpeed = UnityEngine.Random.Range(blendSpeed, blendSpeed + blendVar); // add random so not all animations are the same
    }

    void Update()
    {
        if (increase)
        {
        blendValue = blendValue + Time.deltaTime * blendSpeed;
            if (blendValue >= 1f)
            {
                increase = false;
            }
        }

        else
        {
            blendValue = blendValue - Time.deltaTime * blendSpeed;            
            if (blendValue <= 0f)
            {
                increase = true;
            }

        }

        endBlend = Mathf.SmoothStep(0f, 100f, blendValue);

        skinMesh.SetBlendShapeWeight(0, endBlend);
    }
}
