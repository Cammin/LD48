using DefaultNamespace;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ComponentPooler<T> where T : Component, IPooledObject
{
    private readonly T _prefab;
    private readonly IObjectPool<T> _pool;


    public T Get()
    {
        return _pool.Get();
    }
    
    protected ComponentPooler(T prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<T>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    protected virtual T OnCreate()
    {
        T pooledObject = Object.Instantiate(_prefab);
        ReturnToPool<T> returnToPool = pooledObject.gameObject.AddComponent<ReturnToPool<T>>();
        returnToPool.Init(_pool, pooledObject);
        
        return pooledObject;
    }
    
    protected virtual void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }
    
    protected virtual void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }
    
    protected virtual void OnDestroy(T obj)
    {
        Object.Destroy(obj.gameObject);
    }
}