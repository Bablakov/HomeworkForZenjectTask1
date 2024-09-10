using SecondExample.AddedScripts;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : CoroutineWorker
{
    private EnemySpawner _spawner;
    private float _spawnCooldown;
    private List<Transform> _spawnPoints;

    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    private void Awake()
    {
        _spawner.StartWork();
    }
}
