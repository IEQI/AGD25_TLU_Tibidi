using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public enum ProtAffinity
{
    Spike,
    Receptor
}

public enum ProtType
{
    A,
    B,
    C,
    D
}


[CreateAssetMenu(fileName = "Prot1", menuName = "ScriptableObjects/Proteins")]
public class ScriptObjList : ScriptableObject
{
    public ProtType protType;
    public ProtAffinity protAffinity;

    [SerializeField] MeshRenderer SpikeA;
    [SerializeField] MeshRenderer SpikeB;
    [SerializeField] MeshRenderer SpikeC;
    [SerializeField] MeshRenderer SpikeD;

    [SerializeField] MeshRenderer ReceptA;
    [SerializeField] MeshRenderer ReceptB;
    [SerializeField] MeshRenderer ReceptC;
    [SerializeField] MeshRenderer ReceptD;

    public MeshRenderer GetMeshVisual()
    {
        switch (protAffinity)
        {
            case ProtAffinity.Spike:
                switch (protType)
                {
                    case ProtType.A:
                        return SpikeA;
                    case ProtType.B:
                        return SpikeB;
                    case ProtType.C:
                        return SpikeC;
                    case ProtType.D:
                        return SpikeD;
                }
                break;
            case ProtAffinity.Receptor:
                switch (protType)
                {
                    case ProtType.A:
                        return ReceptA;
                    case ProtType.B:
                        return ReceptB;
                    case ProtType.C:
                        return ReceptC;
                    case ProtType.D:
                        return ReceptD;
                }
                break;
        }
        return null;
    }



}
