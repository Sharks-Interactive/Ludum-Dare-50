using UnityEngine;
using Chrio.Entities;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Data/BuildablesDef", fileName = "New Buildables Defenition")]
public class BuildablesDef : ScriptableObject
{
    public List<RoomData> Buildables = new List<RoomData>();
}
