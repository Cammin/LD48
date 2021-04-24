using UnityEngine;

public class GlowBulb : Pickup
{
    [SerializeField] private float _lightGained = 1;

    public override void OnPickup(Player player)
    {
        player.ApplyLight(_lightGained);
    }

}