using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StartingServicePool : MonoBehaviour
{
    
    PrefabInstantiator instantiator;

    public Dictionary<PoolType, Queue<GameObject>> poolDictionary;
    [Inject]
    void Init(PrefabInstantiator _instantinator)
    {
        instantiator = _instantinator;
    }
    private void Start()
    {
        instantiator.StartMapping();
        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach (PoolType pt in Enum.GetValues(typeof(PoolType)))
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            poolDictionary.Add(pt, queue);

            for (int i = 0; i < 20; i++)
            {
                GameObject obj = instantiator.InstantiatePrefab(pt);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
        }
    }

}
