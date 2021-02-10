using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPrefab : MonoBehaviour
{
    [SerializeField]
    PrefabConfig config;

    private void Awake()
    {
        Instantiate(config.prefab[Random.Range(0, config.prefab.Count)], gameObject.transform);
    }
}
