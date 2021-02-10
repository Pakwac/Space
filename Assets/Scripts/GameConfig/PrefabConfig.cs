using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prefab Config", fileName = "New prefab Config")]
public class PrefabConfig : ScriptableObject
{
    public List<GameObject> prefab;
}
