using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtParent : MonoBehaviour
{
    public ScriptObjList scriptObj;
    MeshRenderer newMesh;
    MeshFilter newFilter;
    MeshRenderer oldMesh;
    MeshFilter oldFilter;

    void Start()
    {
        oldMesh = GetComponent<MeshRenderer>();
        oldFilter = GetComponent<MeshFilter>();

        UpdateMesh();

    }


    public void UpdateMesh() 
    {
        if (scriptObj != null)
        {
            newMesh = scriptObj.GetMeshVisual();
            newFilter = newMesh.GetComponent<MeshFilter>();

            oldMesh.sharedMaterial = newMesh.sharedMaterial;
            oldFilter.sharedMesh = newFilter.sharedMesh;

        }
        else
        {
            Debug.Log("No script object assigned to " + gameObject.name);
        }
    }


    void Update()
    {

    }

}
