using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [SerializeField] private UnderwaterObject[] _prefabs;
    [SerializeField] private AnimationCurve _spawnTimeOverTime;
    [SerializeField] private float _spawnVariancePosition;
    
    private readonly Timer _spawnCooldown = new Timer();

    private readonly Dictionary<UnderwaterObject, UnderwaterObjectPooler<UnderwaterObject>> _poolers = new Dictionary<UnderwaterObject, UnderwaterObjectPooler<UnderwaterObject>>();
    

    public void TryAddDictionaryEntry(UnderwaterObject obj)
    {
        if (_poolers.ContainsKey(obj))
        {
            return;
        }
        _poolers.Add(obj, new UnderwaterObjectPooler<UnderwaterObject>(obj));
    }

    public UnderwaterObjectPooler<UnderwaterObject> GetPoolerForPrefab(UnderwaterObject obj)
    {
        TryAddDictionaryEntry(obj);
        
        return _poolers[obj];
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
        UnderwaterObject atRandom = _prefabs.PickAtRandom();
        UnderwaterObjectPooler<UnderwaterObject> pooler = GetPoolerForPrefab(atRandom);
        UnderwaterObject underwaterObject = pooler.Get();
        
        transform.position = new Vector2(_spawnVariancePosition.AsRandomVariance(), transform.position.y);
        underwaterObject.PooledObj.transform.position = transform.position;
        underwaterObject.Init();
    }

    private void SetTimer()
    {
        _spawnCooldown.Set(_spawnTimeOverTime.Evaluate(Time.time));
    }
}
