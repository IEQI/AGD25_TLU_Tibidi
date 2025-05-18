using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCellManager : MonoBehaviour
{
    
    public GameObject[] spawnPoints;
    public GameObject spikeToSpawn;

    public void Spawn() // Instantiates a spike at a random spawn point.
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        GameObject selectedPoint = spawnPoints[randomPoint];
        Transform worldTransform = selectedPoint.transform;

        Instantiate(spikeToSpawn, worldTransform.position, worldTransform.rotation);

    }


}
