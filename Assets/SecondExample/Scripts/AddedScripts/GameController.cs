using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private EnemySpawner _enemySpawner;

    [Inject]
    private void Construct(EnemySpawner enemySpawner)
        => _enemySpawner = enemySpawner;

    private void Awake()
    {
        _enemySpawner.StartWork();
    }
}