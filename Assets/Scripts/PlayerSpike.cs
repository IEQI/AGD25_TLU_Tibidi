using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpike : ProtParent
{
    //[HideInInspector] public GameObject slot1 = null;

    public int currentSlot;
    private bool slotFull;

    protected override void Start()
    {
        base.Start();
        

        //On first scene load update mesh with default script obj
        if (PlayerSaveStatus.hasRunOnce == false)
        {
            PlayerSaveStatus.spikeList[currentSlot] = scriptObj;
            UpdateMesh();
            slotFull = true;
        }

        else if (PlayerSaveStatus.hasRunOnce == true)
        {            
            //not first load and when list is not empty
            if (PlayerSaveStatus.spikeList[currentSlot] != null)
            {
                scriptObj = PlayerSaveStatus.spikeList[currentSlot];
                UpdateMesh();
                slotFull = true;
            }

            //not first load and when list is empty
            else if (PlayerSaveStatus.spikeList[currentSlot] == null)
            {
                slotFull = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (slotFull == true 
            && other.GetComponent<ProtParent>().scriptObj.protType == scriptObj.protType 
            && other.GetComponent<ProtParent>().scriptObj.protAffinity != scriptObj.protAffinity)
        {
            ClearMesh();
            PlayerSaveStatus.spikeList[currentSlot] = null;
            slotFull = false;

            other.GetComponent<ProtParent>().MatchFound();
        }

        else
        {
            //Debug.Log("Triggered but no match");

        }



    }

    void Update()
    {
        
    }
}
