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

        if (sceneToLoad == "Scene2" )
        {
            //player
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
