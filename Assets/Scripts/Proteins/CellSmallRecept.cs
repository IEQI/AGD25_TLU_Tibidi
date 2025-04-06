using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSmallRecept : ProtParent
{

    public bool slotActive = true;
    public GameObject spikeVisual;

    protected override void Start()
    {
        base.Start();
        UpdateMesh();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (slotActive == true
            && other.GetComponent<ProtParent>().scriptObj.protType == scriptObj.protType
            && other.GetComponent<ProtParent>().scriptObj.protAffinity != scriptObj.protAffinity
            && other.GetComponent<PlayerSpike>().slotFull == true)
        {
            
            spikeVisual.GetComponent<ProtParent>().scriptObj = other.GetComponent<ProtParent>().scriptObj;
            spikeVisual.GetComponent<ProtParent>().UpdateMesh();
        }
    }

    public void Deactivate()
    {
        slotActive = false;
    }


        void Update()
    {
        
    }
}
