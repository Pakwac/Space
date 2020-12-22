using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> asteroid = new List<GameObject>();
    [SerializeField]
    List<GameObject> explosion = new List<GameObject>();
    [SerializeField]
    List<GameObject> shoot = new List<GameObject>();   
    PollObjHelper Asteroids;
    PollObjHelper Explosion;
    PollObjHelper Shoots;
    [SerializeField]
    Transform shootPosition;

    
    void Start()
    {
        AsteroidSpawnManager.NeedSpawnAsteroid += SpawnAsteroid;
        AsteroidLifetimeController.OnDamageAsteroid += AsteroidOnDestroy;
        ExplosionLifetimeController.explosionLifeTime += ExplosionLifeTime;
        PlayerShootController.onFires += OnShoot;
        Asteroids = new PollObjHelper();
        Explosion = new PollObjHelper();
        Shoots = new PollObjHelper();
    }

    private void SpawnAsteroid(Vector3 asteroidPosition)
    {        
        Asteroids.Spawn(asteroidPosition, asteroid, Vector3.back * 20);
    }

    private void AsteroidOnDestroy(Transform currentAsteroidOnDamage)
    {
       
        Asteroids.OnDamage(currentAsteroidOnDamage);
        var boom = Explosion.Spawn(currentAsteroidOnDamage.position, explosion);
        boom.gameObject.GetComponent<Detonator>().Explode();
    }

    private void ExplosionLifeTime(Transform position)
    {
        Explosion.OnDamage(position);
    }

    private void OnShoot()
    {
        Shoots.Spawn(shootPosition.position, shoot, Vector3.forward * 100, Quaternion.identity);
    }
}




