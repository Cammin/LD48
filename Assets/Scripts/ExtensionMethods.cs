using UnityEngine;

public static class ExtensionMethods
{
    public static float AsRandomVariance(this float value)
    {
        return Random.Range(-value, value);
    }
}