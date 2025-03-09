using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeManager : MonoBehaviour
{
    [HideInInspector] public GameObject slot1 = null;
    [HideInInspector] public GameObject slot2 = null;
    [HideInInspector] public GameObject slot3 = null;
    public GameObject spikePrefab;



    void Start()
    {
        Transform slot1Trans = transform.Find("ProtSlot1");
        Transform slot2Trans = transform.Find("ProtSlot2");
        Transform slot3Trans = transform.Find("ProtSlot3");
        //Debug.Log(PlayerSpikeStatus.hasRunOnce);





        if (PlayerSpikeStatus.hasRunOnce == false)
        {
            Debug.Log("First time");

            GameObject slot1Instance = Instantiate(spikePrefab, slot1Trans.position, slot1Trans.rotation);
            slot1Instance.transform.SetParent(transform);
            slot1 = slot1Instance;

            GameObject slot2Instance = Instantiate(spikePrefab, slot2Trans.position, slot2Trans.rotation);
            slot2Instance.transform.SetParent(transform);
            slot2 = slot2Instance;

            GameObject slot3Instance = Instantiate(spikePrefab, slot3Trans.position, slot3Trans.rotation);
            slot3Instance.transform.SetParent(transform);
            slot3 = slot3Instance;

            PlayerSpikeStatus.hasRunOnce = true;
        }

        else if (PlayerSpikeStatus.hasRunOnce == true)
        {
            Debug.Log("Not first time");

            PlayerSpikeStatus.slot1 = slot1;
            //Debug.Log(PlayerSpikeStatus.slot1);

            PlayerSpikeStatus.slot2 = slot2;
            //Debug.Log(PlayerSpikeStatus.slot2);

            PlayerSpikeStatus.slot3 = slot3;
            //Debug.Log(PlayerSpikeStatus.slot3);

        }

        Debug.Log(PlayerSpikeStatus.slot1);
        Debug.Log(PlayerSpikeStatus.slot2);
        Debug.Log(PlayerSpikeStatus.slot3);

    }

    public void SpikeCheck()
    {
        
        PlayerSpikeStatus.slot1 = slot1;
        PlayerSpikeStatus.slot2 = slot2;
        PlayerSpikeStatus.slot3 = slot3;


    }

    void Update()
    {
        
    }
}
