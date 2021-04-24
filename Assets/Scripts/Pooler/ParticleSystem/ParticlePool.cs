using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class ParticlePool : Singleton<ParticlePool>
{
    [SerializeField] private ParticleSystem _prefab;
    
    private IObjectPool<ParticleSystem> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<ParticleSystem>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
    }

    public static void Create(Vector2 pos, Color color)
    {
        ParticleSystem system = Instance._pool.Get();
        ParticleSystem.MainModule main = system.main;

        system.transform.position = pos;
        main.startColor = color;
        
        system.Play();
    }

    private ParticleSystem CreatePooledItem()
    {
        ParticleSystem ps = Instantiate(_prefab);

        ParticleReturnToPool returnToPool = ps.gameObject.AddComponent<ParticleReturnToPool>();
        returnToPool.Pool = _pool;

        return ps;
    }

    private void OnReturnedToPool(ParticleSystem system)
    {
        system.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(ParticleSystem system)
    {
        system.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(ParticleSystem system)
    {
        Destroy(system.gameObject);
    }
}