using System;
using UnityEngine;

public abstract class UnderwaterObject : MonoBehaviour, IPooledObject
{
    private const float DESPAWN_POSITION = 15;
    
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _spawnAngularVelocity;

    public Component PooledObj => this;
    public event Action ReleaseAction;

    public void Init()
    {
        _rb.velocity = Vector2.up * GameManager.DescendSpeed;
        _rb.angularVelocity = _spawnAngularVelocity.AsRandomVariance();
    }



    private void Update()
    {
        if (transform.position.y > DESPAWN_POSITION)
        {
            Release();
        }
    }

    protected void Release()
    {
        //we only have our release action if we were pooled.
        if (ReleaseAction != null)
        {
            ReleaseAction?.Invoke();
            return;
        }
        Destroy(gameObject);
        
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = Vector2.up * DESPAWN_POSITION;
        
        Gizmos.DrawLine(origin + Vector2.left, origin + Vector2.right);
    }
}