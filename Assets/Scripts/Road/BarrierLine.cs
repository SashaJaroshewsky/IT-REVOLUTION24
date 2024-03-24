using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Road
{
    public class BarrierLine : MonoBehaviour, IPoolable
    {
        [SerializeField] private List<Transform> _barrierPoints;

        [SerializeField] private List<Barrier> _barriers;
        private Barrier _barrier;

        public GameObject GameObject => gameObject;

        public event Action<IPoolable> Destroyed;

        public void Reset()
        {
            Destroyed?.Invoke(this);
            _barrier.Reset();
        }

        public void SpawnRandomBareier()
        {
            Transform barrirPoint = _barrierPoints[Random.Range(0, _barrierPoints.Count)];
            Barrier barrier = _barriers[Random.Range(0, _barriers.Count)];
            _barrier = ObjectPool.Instance.GetObject(barrier);
            _barrier.transform.SetParent(transform);
            _barrier.transform.position = barrirPoint.position;
        }




    }
}
