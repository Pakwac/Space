using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PrefabInstantiator
{
    [Inject]
    GameConfig gameConfig;
    [Inject]
    AsteroidLifetimeController.Facktory asteroidFacktory;
    [Inject]
    EnemyAi.Facktory enemyFacktory;
    [Inject]
    Explosion.Facktory explosionFacktory;
    [Inject]
    ShotController.Facktory shotFacktory;

    public Dictionary<PoolType, List<GameObject>> PrefabsMap;
   

    public void StartMapping()
    {
        PrefabsMap = new Dictionary<PoolType, List<GameObject>>();
        PrefabsMap.Add(PoolType.Asteroid, gameConfig.Asteroids);
        PrefabsMap.Add(PoolType.Enemy, gameConfig.Enemies);
        PrefabsMap.Add(PoolType.Bullet, gameConfig.Bullets);
        PrefabsMap.Add(PoolType.Explosion, gameConfig.Explosions);
    }
    public GameObject InstantiatePrefab(PoolType pt)
    {
        switch (pt)
        {
            case PoolType.Asteroid:
              return asteroidFacktory.Create().gameObject;
            case PoolType.Enemy:
                return enemyFacktory.Create().gameObject;
            case PoolType.Explosion:
                return explosionFacktory.Create().gameObject;
            case PoolType.Bullet:
                return shotFacktory.Create().gameObject;
        }
        throw new System.Exception($"Unknown type {pt}"); 
    }

   
}
