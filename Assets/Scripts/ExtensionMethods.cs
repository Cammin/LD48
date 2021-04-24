using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtensionMethods
{
    public static float AsRandomVariance(this float value)
    {
        return Random.Range(-value, value);
    }
    public static T PickAtRandom<T>(this IEnumerable<T> value)
    {
        if (value == null)
        {
            return default;
        }

        List<T> list = value.ToList();
        
        int max = list.Count - 1;
        int range = Random.Range(0, max);

        return list[range];
    }
}