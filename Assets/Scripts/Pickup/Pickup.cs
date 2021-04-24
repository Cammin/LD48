using System;
using UnityEngine;

public abstract class Pickup : UnderwaterObject
{
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private Color _collectFXColor;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.HasGameEnded)
        {
            return;
        }
        
        if (!other.gameObject.TryGetComponent<Player>(out var player))
        {
            return;
        }

        Debug.Log("PICKUP");
        OnPickup(player);
        AudioSource.PlayClipAtPoint(_collectSound, Vector3.zero);
        ParticlePool.Create(transform.position, _collectFXColor);
        
        
        Release();
        
    }

    public abstract void OnPickup(Player player);
    
}