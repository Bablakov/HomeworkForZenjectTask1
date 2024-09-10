using SecondExample.AddedScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner
{
    private float _spawnCooldown;
    private List<Transform> _spawnPoints;
    private EnemyFactory _enemyFactory;
    private Coroutine _spawn;
    private CoroutineWorker _coroutineWorker;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, CoroutineWorker coroutineWorker)
    {
        _enemyFactory = enemyFactory;
        _coroutineWorker = coroutineWorker;
    }

    public EnemySpawner(float spawnCooldown, IEnumerable<Transform> spawnPoints)
    {
        _spawnCooldown = spawnCooldown;
        _spawnPoints = new List<Transform>(spawnPoints);
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _coroutineWorker.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _coroutineWorker.StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
