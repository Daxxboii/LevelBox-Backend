using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Data", menuName = "ScriptableObjects/NewBlockData", order = 1)]

public class BlocksData : ScriptableObject
{
    public string BlockName;
    public byte BlockUniqueID;


}
