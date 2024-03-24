using System;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPoolable
    {
        GameObject GameObject { get; }
        event Action<IPoolable> Destroyed;
        void Reset();
    }
}
