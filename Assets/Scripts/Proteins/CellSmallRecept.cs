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
            && other.TryGetComponent<PlayerSpike>(out var playerSpike) // check if other spike is attached to player in the edge case where a spike is shot straight to another cell's receptor
            && playerSpike.slotFull == true
            && playerSpike.scriptObj.protType == scriptObj.protType
            && playerSpike.scriptObj.protAffinity != scriptObj.protAffinity
            )

        {            
            spikeVisual.GetComponent<ProtParent>().scriptObj = playerSpike.scriptObj;
            spikeVisual.GetComponent<ProtParent>().UpdateMesh();            
            GetComponentInParent<SmallCellManager>().Spawn(); //Spawns a new spike
            playerSpike.slotFull = false;
            playerSpike.scriptObj = null; // scriptObj is cleared after recept has updated it's spike
            Deactivate();
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
