using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public abstract class GameSpawner<T> : MonoBehaviour where T : UnderwaterObject, IPooledObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private AnimationCurve _spawnTimeOverTime;
    
    private readonly Timer _spawnCooldown = new Timer();

    private UnderwaterObjectPooler<T> _pooler;

    private void Awake()
    {
        _pooler = new UnderwaterObjectPooler<T>(_prefab);
    }

    private void Start()
    {
        
        SetTimer();
    }

    private void Update()
    {
        if (_spawnCooldown.IsRunning)
        {
            return;
        }

        Spawn();
    }

    private void Spawn()
    {
        T underwaterObject = _pooler.Get();
    }

    private void SetTimer()
    {
        _spawnCooldown.Set(_spawnTimeOverTime.Evaluate(Time.time));
    }
}
