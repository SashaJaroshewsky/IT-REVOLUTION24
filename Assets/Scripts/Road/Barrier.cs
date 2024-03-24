using System;
using UnityEngine;

namespace Assets.Scripts.Road
{
    internal class Barrier: MonoBehaviour, IPoolable
    {
        public GameObject GameObject => gameObject;

        
        public event Action<IPoolable> Destroyed;

        public void Reset()
        {
            Destroyed?.Invoke(this);
        }
    }
}
