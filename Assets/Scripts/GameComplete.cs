using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{

    public string sceneToLoad;
    public GameObject completeText;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            completeText.SetActive(true);
            Invoke(nameof(LoadMenu), 3f);

        }

    }

    void LoadMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }


}
