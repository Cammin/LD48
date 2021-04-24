using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{

    [SerializeField] private Light2D _light;
    [SerializeField] private float _smooth = 1;
    [SerializeField] private float _maxSmoothSpeed = 100;

    [SerializeField] private float _minimumVisibility = 0.2f;
    [SerializeField] private float _decaySpeed;
    
    private float _currentVisibility;
    private float _targetVisbility;

    private float _currentVelocity;

    private void Update()
    {
        DecayUpdate();
    }


    public void DecayUpdate()
    {
        _targetVisbility = Mathf.Max(_targetVisbility - Time.deltaTime * _decaySpeed, _minimumVisibility);
    }

    public void IncreaseVisibility()
    {
        
    }

    public void UpdateLight()
    {
        _currentVisibility = Mathf.SmoothDamp(_currentVisibility, _targetVisbility, ref _currentVelocity, _smooth, _maxSmoothSpeed, Time.deltaTime);
        _light.intensity = _currentVisibility;
    }
}