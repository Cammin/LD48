using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLighting : Singleton<GlobalLighting>
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _decayRate = 0.02f;
    
    //damp
    [SerializeField] private float _lightSmooth = 1;
    [SerializeField] private float _maxDampSpeed = 100;

    private float _currentIntensity;
    private float _targetIntensity;
    private float _velocityIntensity;

    private void Start()
    {
        _targetIntensity = _light.intensity;
    }

    public void Update()
    {
        if (!GameManager.HasGameStarted)
        {
            return;
        }
        
        DecayTargetIntensity();
        UpdateCurrentIntensity();
        Instance._light.intensity = _currentIntensity;
    }

    private void UpdateCurrentIntensity()
    {
        _currentIntensity = Mathf.SmoothDamp(_currentIntensity, _targetIntensity, ref _velocityIntensity, _lightSmooth, _maxDampSpeed, Time.deltaTime);
    }

    private void DecayTargetIntensity()
    {
        float delta = -_decayRate * Time.deltaTime;
        _targetIntensity = Mathf.Max(_targetIntensity + delta, 0);
    }

    public static void SetIntensity(float instensityUponCollect)
    {
        Instance._targetIntensity = instensityUponCollect;
    }
}
