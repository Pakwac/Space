using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolManager
{
    [Inject]
    PrefabInstantiator instantiator;
    [Inject]
    StartingServicePool startingService;

    public GameObject GetObjectFromPool(PoolType pt)
    {
        if (startingService.poolDictionary[pt].Count > 0)
        {
            GameObject objecToSpawn = startingService.poolDictionary[pt].Dequeue();
            objecToSpawn.SetActive(true);
            return objecToSpawn;
        }
        else
        {
            GameObject objecToSpawn = instantiator.InstantiatePrefab(pt);
            objecToSpawn.SetActive(true);
            return objecToSpawn;
        }
    }

    public void ReturnToPool(GameObject obj, PoolType pt)
    {
        startingService.poolDictionary[pt].Enqueue(obj);
        obj.SetActive(false);
    }

}