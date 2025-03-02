using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShapeKey : MonoBehaviour
{

    SkinnedMeshRenderer skinMesh;
    void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
        skinMesh.SetBlendShapeWeight(0, 100);
    }

    void Update()
    {
        
    }
}
