using UnityEngine;

public class Starfish : Pickup
{
    [SerializeField] private float _instensityUponCollect = 0.25f;
    
    public override void OnPickup(Player player)
    {
        GlobalLighting.SetIntensity(_instensityUponCollect);
    }

    public UnderwaterObject UnderwaterObject { get; }
}