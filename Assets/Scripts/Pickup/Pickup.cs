using System;
using UnityEngine;

public abstract class Pickup : UnderwaterObject
{
    
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<Player>(out var player))
        {
            return;
        }
        
        OnPickup(player);
        
    }

    public abstract void OnPickup(Player player);
    
}