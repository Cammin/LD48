using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    private IPooledObject _pooledObject;
    private IObjectPool<IPooledObject> _pool;
        
    public void Init(IObjectPool<IPooledObject> pool, IPooledObject pooledObject)
    {
        _pool = pool;
        _pooledObject = pooledObject;

        _pooledObject.ReleaseAction += Release;
    }

    private void Release()
    {
        _pool.Release(_pooledObject);
    }
}