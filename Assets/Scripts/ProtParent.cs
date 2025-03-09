using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtParent : MonoBehaviour
{
    public int protType;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recept" && other.gameObject.GetComponent<ProtParent>().protType == 1) 
        {
            
            Destroy(other.gameObject);
            Destroy(gameObject);
            //GetComponentInParent<PlayerSpikeManager>().SpikeCheck();
        }    
    }


}
