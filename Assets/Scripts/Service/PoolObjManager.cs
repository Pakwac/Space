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
    [SerializeField]
    List<GameObject> enemy = new List<GameObject>();
    PollObjHelper Asteroids;
    PollObjHelper Explosion;
    PollObjHelper Shoots;
    PollObjHelper Enemys;
    [SerializeField]
    Transform shootPosition;

    
    void Start()
    {
        AsteroidSpawnManager.NeedSpawnAsteroid += SpawnAsteroid;
        AsteroidLifetimeController.OnDamageAsteroid += AsteroidOnDestroy;
        ExplosionLifetimeController.explosionLifeTime += ExplosionLifeTime;
        PlayerShootController.onFires += OnShoot;
        EnemySpawnManager.NeedSpawnEnemy += SpawnEnemy;
        EnemyAi.OnDeath += DeathEnemy;
        EnemyAi.Shoot += OnShoot;
        PlayerLifetimeController.playerIsDead += OnPlayerDeath;
        Asteroids = new PollObjHelper();
        Explosion = new PollObjHelper();
        Shoots = new PollObjHelper();
        Enemys = new PollObjHelper();

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

    private void OnShoot(Transform position, Vector3 speed, string tag)
    {
        Shoots.Spawn(position.position, shoot, speed, Quaternion.identity, tag);
    }

    private void SpawnEnemy(Vector3 position)
    {
        Enemys.Spawn(position, enemy, Vector3.back * 20, Quaternion.identity);
    }

    private void DeathEnemy(Transform position)
    {
        Explosion.Spawn(position.position, explosion);
        AsteroidOnDestroy(position);
    }

    private void OnPlayerDeath(Transform position)
    {
        position.gameObject.SetActive(false);
        var boom = Explosion.Spawn(position.position, explosion);
        boom.gameObject.GetComponent<Detonator>().Explode();
    }
}




