using UnityEngine;

public class UnderwaterObjectPooler<T> : ComponentPooler<T> where T : UnderwaterObject, IPooledObject
{
    public UnderwaterObjectPooler(T prefab) : base(prefab)
    {
    }

    protected override void OnGet(IPooledObject obj)
    {
        base.OnGet(obj);
        UnderwaterObject underwaterObject = obj as UnderwaterObject;
        if (underwaterObject)
        {
            underwaterObject.Init();
        }
    }
    
}