using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleReturnToPool : MonoBehaviour
{
    public ParticleSystem _system;
    public IObjectPool<ParticleSystem> Pool;

    private void Start()
    {
        _system = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _system.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        Debug.Log("RELEASE");
        Pool.Release(_system);
    }
}