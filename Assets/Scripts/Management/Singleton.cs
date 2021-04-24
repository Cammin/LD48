using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T Instance;

    private void OnEnable()
    {
        Instance = this as T;
    }

    private void OnDisable()
    {
        Instance = null;
    }
}