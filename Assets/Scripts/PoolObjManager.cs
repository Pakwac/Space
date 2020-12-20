using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjManager : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;
    [SerializeField]
    GameObject explosion;
    List<GameObject> asteroids = new List<GameObject>();
    PollObjHelper Asteroids;
    PollObjHelper Explosion;
    // Start is called before the first frame update
    void Start()
    {
        AsteroidSpawnManager.NeedSpawnAsteroid += SpawnAsteroid;
        AsteroidLifetimeController.OnDamageAsteroid += AsteroidOnDestroy;
        ExplosionLifetimeController.explosionLifeTime += ExplosionLifeTime;
        Asteroids = new PollObjHelper();
        Explosion = new PollObjHelper();
    }

    private void SpawnAsteroid(Vector3 asteroidPosition)
    {        
        Asteroids.Spawn(asteroidPosition, asteroid, Vector3.back * 20);
    }

    private void AsteroidOnDestroy(Transform currentAsteroidOnDamage)
    {
        Explosion.Spawn(currentAsteroidOnDamage.position, explosion);
        Asteroids.OnDamage(currentAsteroidOnDamage);
    }

    private void ExplosionLifeTime(Transform position)
    {
        Explosion.OnDamage(position);
    }
}




