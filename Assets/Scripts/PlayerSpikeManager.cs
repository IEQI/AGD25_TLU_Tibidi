using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeManager : MonoBehaviour
{
    [HideInInspector] public GameObject slot1 = null;

    public int currentSlot;
    public GameObject spikePrefab;
    private bool slotFull;
    private GameObject spikeInstRef;


    void Start()
    {


        //On first scene load add default spikes to virus
        if (PlayerSpikeStatus.hasRunOnce == false)
        {
            Transform slotTrans = transform;
            GameObject spikeInstance = Instantiate(spikePrefab, slotTrans.position, slotTrans.rotation);
            spikeInstance.transform.SetParent(transform);
            spikeInstRef = spikeInstance;

            PlayerSpikeStatus.slot[currentSlot] = spikePrefab;
            slotFull = true;

            //Debug.Log(PlayerSpikeStatus.slot[currentSlot].name);


        }

        else if (PlayerSpikeStatus.hasRunOnce == true)
        {

            
            //On not first load and when there should be a spike, then instantiate it
            if (PlayerSpikeStatus.slot[currentSlot] != null)
            {
                Transform slotTrans = transform;
                GameObject spikeInstance = Instantiate(spikePrefab, slotTrans.position, slotTrans.rotation);
                spikeInstance.transform.SetParent(transform);
                spikeInstRef = spikeInstance;
                Debug.Log(PlayerSpikeStatus.slot[currentSlot].name);
                slotFull = true;

            }

            //On not first load and when there should not be a spike, do nothing
            else if (PlayerSpikeStatus.slot[currentSlot] == null)
            {
                Debug.Log(slotFull);

            }

            
            //Transform slotTrans = transform;
            //PlayerSpikeStatus.slot[currentSlot]


        }
                

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recept" && other.gameObject.GetComponent<ProtParent>().protType == 1 && slotFull)
        {

            Destroy(other.gameObject);
            Destroy(spikeInstRef);
            PlayerSpikeStatus.slot[currentSlot] = null;
            slotFull = false;
        }
    }



    void Update()
    {
        
    }
}
