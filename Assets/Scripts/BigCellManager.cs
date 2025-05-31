using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCellManager : MonoBehaviour
{

    public GameObject closedCollider;
    public GameObject openCollider;
    public int fullSlots = 0;
    SkinnedMeshRenderer skinMesh;


    IEnumerator AnimBlendShape(float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float currentWeight = Mathf.Lerp(start, end, t);
            skinMesh.SetBlendShapeWeight(0, currentWeight);
            elapsed = elapsed + Time.deltaTime;
            yield return null;
        }
        skinMesh.SetBlendShapeWeight(0, end);
    }


    void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
        skinMesh.SetBlendShapeWeight(0, 100);

        //GetComponentInParent<SmallCellManager>().Spawn();
    }

    void Update()
    {
        
    }

    public void AddSlots()
    {
        fullSlots++;
        
        if (fullSlots >= 3)
        {
            StartCoroutine(AnimBlendShape(100f, 0f, 2f));

            closedCollider.SetActive(false);
            openCollider.SetActive(true);
        }

        Debug.Log("Slot fullness: " + fullSlots);
    }

    }
