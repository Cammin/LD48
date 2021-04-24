using UnityEngine;
using UnityEngine.Pool;

namespace DefaultNamespace
{
    public class ReturnToPool<T> : MonoBehaviour where T : Component, IPooledObject
    {
        private T _pooledObject;
        private IObjectPool<T> _pool;
        
        public void Init(IObjectPool<T> pool, T pooledObject)
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
}