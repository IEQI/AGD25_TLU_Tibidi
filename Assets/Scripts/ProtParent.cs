using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtParent : MonoBehaviour
{
    public ScriptObjList scriptObjList;
    public int protType;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = scriptObjList.GetMeshVisual();

    }

    void Update()
    {

    }

}
