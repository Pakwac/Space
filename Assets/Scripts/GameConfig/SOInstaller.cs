using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    public GameConfig gameConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(gameConfig).AsSingle();
        
    }
}