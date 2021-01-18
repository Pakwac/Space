using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
        [SerializeField]
        public List<GameObject> Asteroids;
        [SerializeField]
        public List<GameObject> Enemies;
        [SerializeField]
        public List<GameObject> Bullets;
        [SerializeField]
        public List<GameObject> Explosions;

        public Dictionary<PoolType, List<GameObject>> PrefabsMap;
        Dictionary<PoolType, Queue<GameObject>> poolDictionary;

    public static PoolManager Instance;

    private void Awake()
    {
        Instance = this;

        PrefabsMap = new Dictionary<PoolType, List<GameObject>>();
        PrefabsMap.Add(PoolType.Asteroid, Asteroids);
        PrefabsMap.Add(PoolType.Enemy, Enemies);
        PrefabsMap.Add(PoolType.Bullet, Bullets);
        PrefabsMap.Add(PoolType.Explosion, Explosions);

        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach (PoolType pt in Enum.GetValues(typeof(PoolType)))
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            poolDictionary.Add(pt, queue);

            for (int i = 0; i < 20; i++)
            {
                GameObject obj = Instantiate(PrefabsMap[pt][UnityEngine.Random.Range(0, PrefabsMap[pt].Count)]);
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
            GameObject objecToSpawn = Instantiate(PrefabsMap[pt][UnityEngine.Random.Range(0, PrefabsMap[pt].Count)]);
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