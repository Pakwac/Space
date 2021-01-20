using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour, IPrefabInstantiator
{
    public Dictionary<PoolType, List<GameObject>> PrefabsMap;

    [SerializeField]
    public List<GameObject> Asteroids;
    [SerializeField]
    public List<GameObject> Enemies;
    [SerializeField]
    public List<GameObject> Bullets;
    [SerializeField]
    public List<GameObject> Explosions;


    void Awake()
    {
        PrefabsMap = new Dictionary<PoolType, List<GameObject>>();
        PrefabsMap.Add(PoolType.Asteroid, Asteroids);
        PrefabsMap.Add(PoolType.Enemy, Enemies);
        PrefabsMap.Add(PoolType.Bullet, Bullets);
        PrefabsMap.Add(PoolType.Explosion, Explosions);
    }
    public GameObject InstantiatePrefab(PoolType pt)
    {
        return Instantiate(PrefabsMap[pt][UnityEngine.Random.Range(0, PrefabsMap[pt].Count)]);
    }
}
