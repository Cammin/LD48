using System;

namespace DefaultNamespace
{
    public interface IPooledObject
    {
        event Action ReleaseAction;
    }
}