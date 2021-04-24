using DefaultNamespace;
using UnityEngine;

public class UnderwaterObjectPooler<T> : ComponentPooler<T> where T : UnderwaterObject, IPooledObject
{
    public UnderwaterObjectPooler(T prefab) : base(prefab)
    {
    }

    protected override void OnGet(T obj)
    {
        base.OnGet(obj);
        obj.Init();
    }
}