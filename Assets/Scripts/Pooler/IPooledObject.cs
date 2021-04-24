using System;
using UnityEngine;

public interface IPooledObject
{
    Component PooledObj { get; }
    event Action ReleaseAction;
}