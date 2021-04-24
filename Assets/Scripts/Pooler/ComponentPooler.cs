using UnityEngine;
using UnityEngine.Pool;

public abstract class ComponentPooler<T> where T : Component, IPooledObject
{
    private readonly T _prefab;
    private readonly IObjectPool<IPooledObject> _pool;


    public T Get()
    {
        Component pooledObject = _pool.Get().PooledObj;
        return pooledObject as T;
    }
    
    protected ComponentPooler(T prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<IPooledObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    protected virtual IPooledObject OnCreate()
    {
        T pooledObject = Object.Instantiate(_prefab);
        ReturnToPool particleReturnToPool = pooledObject.gameObject.AddComponent<ReturnToPool>();
        particleReturnToPool.Init(_pool, pooledObject);
        
        return pooledObject;
    }
    
    protected virtual void OnGet(IPooledObject obj)
    {
        obj.PooledObj.gameObject.SetActive(true);
    }
    
    protected virtual void OnRelease(IPooledObject obj)
    {
        obj.PooledObj.gameObject.SetActive(false);
    }
    
    protected virtual void OnDestroy(IPooledObject obj)
    {
        Object.Destroy(obj.PooledObj.gameObject);
    }
}