using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private InputActionReference _axis;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _turnAroundThreshold = 0.1f;
    
    private void FixedUpdate()
    {
        Vector2 input = _axis.action.ReadValue<Vector2>();

        //move
        _rb.AddForce(input * _moveSpeed, ForceMode2D.Force);
        
        //restrict breaking the max speed
        Vector2 vel = _rb.velocity;
        vel = vel.normalized * Mathf.Min(vel.magnitude, _maxSpeed);
        _rb.velocity = vel; 
        
        //renderer
        float xVel = _rb.velocity.x;
        if (xVel > _turnAroundThreshold)
        {
            _renderer.flipX = xVel < 0;
        }
        
    }
}