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
            //Debug.Log("Player spike status" + slotFull);
        }

        else if (PlayerSaveStatus.hasRunOnce == true)
        {            
            //not first load and when list is not empty
            if (PlayerSaveStatus.spikeList[currentSlot] != null)
            {
                scriptObj = PlayerSaveStatus.spikeList[currentSlot]; // load scriptObj from save
                UpdateMesh();
                slotFull = true;
            }

            //not first load and when list is empty
            else if (PlayerSaveStatus.spikeList[currentSlot] == null)
            {
                scriptObj = null; // Clear the default reference if it's null in save
                slotFull = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // Attaching player spike to receptor - When there is a spike already and collided object is receptor of the same type
        if (slotFull == true 
            && other.TryGetComponent<CellSmallRecept>(out var cellRecept)
            && cellRecept.slotActive == true
            && cellRecept.scriptObj.protType == scriptObj.protType
            && cellRecept.scriptObj.protAffinity != scriptObj.protAffinity)

        {
            ClearMesh();
            PlayerSaveStatus.spikeList[currentSlot] = null;
            // slotFull is assigned FALSE in CellSmallRecept script
            // scriptObj reference is cleared in CellSmallRecept script
            Debug.Log("Player spike attached");
            PlayerSaveStatus.QueryArray(); // for debugging
        }

        // Picking up a new spike - When spike slot is empty and collided object is a spike
        else if (slotFull == false 
            && other.GetComponent<ProtParent>().scriptObj.protAffinity == ProtAffinity.Spike) 
        {
            scriptObj = other.GetComponent<ProtParent>().scriptObj;
            UpdateMesh();
            PlayerSaveStatus.spikeList[currentSlot] = scriptObj;
            slotFull = true;
            Destroy(other.gameObject); //destroy the floating spike after it has been added to the list
            
            Debug.Log("Player spike picked up spike");
            PlayerSaveStatus.QueryArray(); // for debugging
        }

        else
        {
            Debug.Log("Triggered but no match or full");
            PlayerSaveStatus.QueryArray(); // for debugging
        }



    }

}
