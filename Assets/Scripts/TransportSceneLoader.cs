using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportSceneLoader : MonoBehaviour
{

    public string sceneToLoad;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerSpikeManager>().SpikeCheck();
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
