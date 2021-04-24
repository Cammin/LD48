using System;
using DefaultNamespace;
using UnityEngine;

public abstract class UnderwaterObject : MonoBehaviour, IPooledObject
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _spawnAngularVelocity;

    public event Action ReleaseAction;

    public void Init()
    {
        _rb.AddForce(Vector2.up * GameManager.DescendSpeed);
        _rb.AddTorque(_spawnAngularVelocity.AsRandomVariance());
    }



    private void Update()
    {
        if (transform.position.y > 30)
        {
            ReleaseAction?.Invoke();
        }
    }
}