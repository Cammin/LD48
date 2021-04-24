using System;
using UnityEngine;

public abstract class Pickup : UnderwaterObject
{
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent<Player>(out var player))
        {
            return;
        }

        Debug.Log("PICKUP");
        OnPickup(player);
        Release();
        
    }

    public abstract void OnPickup(Player player);
    
}