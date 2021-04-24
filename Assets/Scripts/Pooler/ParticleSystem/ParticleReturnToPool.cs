using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleReturnToPool : MonoBehaviour
{
    public ParticleSystem _system;
    public IObjectPool<ParticleSystem> Pool;

    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _system.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void OnParticleSystemStopped()
    {
        Pool.Release(_system);
    }
}