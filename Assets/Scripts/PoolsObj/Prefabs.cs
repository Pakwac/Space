using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    [SerializeField]
    public  List<GameObject> Asteroids;
    [SerializeField]
    public List<GameObject> Enemies;
    [SerializeField]
    public List<GameObject> Bullets;
    [SerializeField]
    public List<GameObject> Explosions;


    public Dictionary<PoolType, List<GameObject>> PrefabsMap;
    private void Awake()
    {
        PrefabsMap = new Dictionary<PoolType, List<GameObject>>();
        PrefabsMap.Add(PoolType.Asteroid, Asteroids);
        PrefabsMap.Add(PoolType.Enemy, Enemies);
        PrefabsMap.Add(PoolType.Bullet, Bullets);
        PrefabsMap.Add(PoolType.Explosion, Explosions);
    }
}
