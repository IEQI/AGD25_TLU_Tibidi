using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBigRecept : ProtParent
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
            && other.TryGetComponent<PlayerSpike>(out var playerSpike)
            && playerSpike.slotFull == true
            && playerSpike.scriptObj.protType == scriptObj.protType
            && playerSpike.scriptObj.protAffinity != scriptObj.protAffinity
            )

        {
            // update receptor and player spikes and save
            spikeVisual.GetComponent<ProtParent>().scriptObj = playerSpike.scriptObj;
            spikeVisual.GetComponent<ProtParent>().UpdateMesh();
            playerSpike.slotFull = false;
            PlayerSaveStatus.spikeList[playerSpike.currentSlot] = null;
            playerSpike.ClearMesh();
            playerSpike.scriptObj = null; // scriptObj is cleared after recept has updated it's spike
            Deactivate();
            Debug.Log("Player spike attached");
            //PlayerSaveStatus.QueryArray(); // for debugging

            GetComponentInParent<BigCellManager>().AddSlots();


        }
    }

    public void Deactivate()
    {
        slotActive = false;
    }

}
