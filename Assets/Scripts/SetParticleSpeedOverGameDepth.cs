using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleSpeedOverGameDepth : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _systems;
    [SerializeField] private float _baseSpeedMultiplier = 0.5f;
    private void Update()
    {
        float speed = GameManager.DescendSpeed * _baseSpeedMultiplier;

        Debug.Log(speed);
        foreach (ParticleSystem system in _systems)
        {
            SetSystem(system, speed);
        }
    }

    private void SetSystem(ParticleSystem system, float speed)
    {
        ParticleSystem.MainModule systemMain = system.main;

        systemMain.simulationSpeed = speed;
    }
}
