using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpike : MonoBehaviour
{
    //[HideInInspector] public GameObject slot1 = null;

    public int currentSlot;
    public GameObject spikePrefab;
    private bool slotFull;
    private GameObject spikeInstRef;


    void Start()
    {
        Transform slotTrans = transform;

        //On first scene load add default spikes to virus
        if (PlayerSaveStatus.hasRunOnce == false)
        {
            
            GameObject spikeInstance = Instantiate(spikePrefab, slotTrans.position, slotTrans.rotation);
            spikeInstance.transform.SetParent(transform);
            spikeInstRef = spikeInstance;
            PlayerSaveStatus.slot[currentSlot] = spikePrefab;

            slotFull = true;            
        }

        else if (PlayerSaveStatus.hasRunOnce == true)
        {            
            //On not first load and when there should be a spike, then instantiate it
            if (PlayerSaveStatus.slot[currentSlot] != null)
            {
                GameObject spikeInstance = Instantiate(PlayerSaveStatus.slot[currentSlot], slotTrans.position, slotTrans.rotation);
                spikeInstance.transform.SetParent(transform);
                spikeInstRef = spikeInstance;
                slotFull = true;
            }

            //On not first load and when there should not be a spike, do nothing
            else if (PlayerSaveStatus.slot[currentSlot] == null)
            {
                slotFull = false;
            }

            //Transform slotTrans = transform;
            //PlayerSpikeStatus.slot[currentSlot]
            //Debug.Log(PlayerSpikeStatus.slot[currentSlot].name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recept" && other.gameObject.GetComponent<ProtParent>().protType == 1 && slotFull)
        {
            Destroy(other.gameObject);
            Destroy(spikeInstRef);
            PlayerSaveStatus.slot[currentSlot] = null;
            slotFull = false;
        }
    }

    void Update()
    {
        
    }
}
