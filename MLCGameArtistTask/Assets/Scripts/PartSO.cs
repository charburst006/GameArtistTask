using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "CreatureCreator/Part")]
public class PartSO : ScriptableObject
{
    public Sprite Sprite;
    public List<string> Tags;
}
