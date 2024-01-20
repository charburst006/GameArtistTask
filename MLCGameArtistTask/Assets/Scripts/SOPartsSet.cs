using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartsSet", menuName = "CreatureCreator/PartsSet")]
public class SOPartsSet : ScriptableObject
{
    public List<PartSO> Parts;
}
