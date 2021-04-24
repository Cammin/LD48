using System;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField] private PlayerLight _light;
    [SerializeField] private PlayerMovement _movement;

    public void ApplyLight(float lightAmount)
    {
        _light.IncreaseVisibility(lightAmount);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!GameManager.HasGameStarted || GameManager.HasGameEnded)
        {
            return;
        }
        
        if (other.gameObject.TryGetComponent(out Urchin urchin))
        {
            GameManager.EndGame();
        }
    }
}