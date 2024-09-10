using SecondExample.AddedScripts;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private CoroutineWorker _coroutineWorker;
    [SerializeField, Range(0, 10)] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<CoroutineWorker>().FromInstance(_coroutineWorker);
        Container.Bind<EnemySpawner>().AsSingle().WithArguments(_spawnCooldown, _spawnPoints);
    }
}
