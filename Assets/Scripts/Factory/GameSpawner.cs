using DefaultNamespace;
using UnityEngine;

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
        SetTimer();
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
