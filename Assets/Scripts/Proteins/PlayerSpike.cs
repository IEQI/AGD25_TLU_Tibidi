using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpike : ProtParent
{
    //[HideInInspector] public GameObject slot1 = null;

    public int currentSlot;
    [HideInInspector] public bool slotFull;

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
        
        //When there is a spike already and collided object is receptor of the same type
        if (slotFull == true 
            && other.GetComponent<ProtParent>().scriptObj.protType == scriptObj.protType 
            && other.GetComponent<ProtParent>().scriptObj.protAffinity != scriptObj.protAffinity
            && other.GetComponent<CellSmallRecept>().slotActive == true)
        {
            ClearMesh();
            PlayerSaveStatus.spikeList[currentSlot] = null;
            slotFull = false;

            other.GetComponent<CellSmallRecept>().Deactivate(); //deactivate only after status is updated
        }

        // When there is no spike and collided object is a spike
        else if (slotFull == false && other.GetComponent<ProtParent>().scriptObj.protAffinity == ProtAffinity.Spike) 
        {
            scriptObj = other.GetComponent<ProtParent>().scriptObj;
            UpdateMesh();
            PlayerSaveStatus.spikeList[currentSlot] = scriptObj;
            slotFull = true;
            Destroy(other.gameObject); //destroy the floating spike after it has been added to the list

        }

        else
        {
            Debug.Log("Triggered but no match");
        }



    }

}
