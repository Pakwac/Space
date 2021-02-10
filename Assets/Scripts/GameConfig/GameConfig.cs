using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Game Config", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    //[SerializeField]
    //private GameConfig gameConfig;

    [SerializeField]
    public List<GameObject> Asteroids;
    [SerializeField]
    public List<GameObject> Enemies;
    [SerializeField]
    public List<GameObject> Bullets;
    [SerializeField]
    public List<GameObject> Explosions;
}
