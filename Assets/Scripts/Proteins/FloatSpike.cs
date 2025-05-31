using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatSpike : ProtParent
{
    
    
    protected override void Start()
    {
        base.Start();
        UpdateMesh();
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100);
        //Debug.Log("Float spike emitted");
    }

    void Update()
    {
        
    }
}
