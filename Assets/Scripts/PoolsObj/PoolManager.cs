using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour,  IPoolManager
{
    IPrefabInstantiator instantiator;

    Dictionary<PoolType, Queue<GameObject>> poolDictionary;

    public static PoolManager Instance;

    PoolManager(IPrefabInstantiator inst)
    {
       
    }

    private void Awake()
    {
        Instance = this;
        instantiator = gameObject.GetComponent<PrefabInstantiator>();
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

    public GameObject GetObjectFromPool(PoolType pt)
    {
        if (poolDictionary[pt].Count > 0)
        {
            GameObject objecToSpawn = poolDictionary[pt].Dequeue();
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
        poolDictionary[pt].Enqueue(obj);
        obj.SetActive(false);
    }

}