using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public StartingServicePool pool;

    public GameObject enemyPrefab;
    public GameObject asteroidPrefab;
    public GameObject explosionPrefab;
    public GameObject shotPrefab;

    PoolType pt;

 
    public override void InstallBindings()
    {
        Container.Bind<PrefabInstantiator>().AsSingle();
        Container.Bind<StartingServicePool>().FromInstance(pool).AsSingle().NonLazy();
        Container.Bind<PoolManager>().AsSingle();

        Container.BindFactory<EnemyAi, EnemyAi.Facktory>().FromComponentInNewPrefab(enemyPrefab);

        Container.BindFactory<AsteroidLifetimeController, AsteroidLifetimeController.Facktory>().FromComponentInNewPrefab(asteroidPrefab);

        Container.BindFactory<ShotController, ShotController.Facktory>().FromComponentInNewPrefab(shotPrefab);

        Container.BindFactory<Explosion, Explosion.Facktory>().FromComponentInNewPrefab(explosionPrefab);
    }
}