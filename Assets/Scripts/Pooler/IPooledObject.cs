using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IPooledObject
    {
        Component PooledObj { get; }
        event Action ReleaseAction;
    }
}