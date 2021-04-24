using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField] private PlayerLight _light;
    [SerializeField] private PlayerMovement _movement;

    public void ApplyLight(float lightAmount)
    {
        _light.IncreaseVisibility(lightAmount);
    }
        
}