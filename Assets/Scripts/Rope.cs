using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Sprite _tugged;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _upForceAfterGame = 0.1f;
    private void FixedUpdate()
    {
        if (GameManager.HasGameEnded)
        {
            _rb.AddForce(Vector2.up * _upForceAfterGame);
            _renderer.sprite = _tugged;
        }
    }
}
