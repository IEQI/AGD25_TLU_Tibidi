using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSaveStatus
{
    public static bool hasRunOnce = false;
    //public static GameObject[] slot = new GameObject[3];
    public static ScriptObjList[] spikeList = new ScriptObjList[3];

    public static void QueryArray() // for debugging
    {
        for (int i = 0; i < spikeList.Length; i++)
        {
            if (spikeList[i] != null)
            {
                Debug.Log($"Index {i}: {spikeList[i].name}");
            }
            else
            {
                Debug.Log($"Index {i}: Null");
            }
        }
    }

}
