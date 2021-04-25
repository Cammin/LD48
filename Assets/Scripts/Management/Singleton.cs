using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T Instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetInstance()
    {
        if (!Instance)
        {
            Singleton<T> instance = Instance as Singleton<T>;
            instance.ResetStatics();
            Instance = null;
        }
    }
    protected virtual void ResetStatics(){}
    
    protected virtual void OnEnable()
    {
        Instance = this as T;
    }

    protected virtual void OnDisable()
    {
        Instance = null;
    }
}