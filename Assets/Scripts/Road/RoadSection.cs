using System;
using UnityEngine;

namespace Assets.Scripts.Road
{
    public class RoadSection : MonoBehaviour, IPoolable
    {
        [SerializeField] private Transform _carSpawn;
        [SerializeField] private Transform _barrierLinePosition;
        [SerializeField] private BarrierLine _barrierLinePrefab;
        public GameObject GameObject => gameObject;
        public Transform CarSpawn => _carSpawn;
        public event Action<IPoolable> Destroyed;
        public event Action TriggeredEnter;
        public event Action<RoadSection> TriggeredExit;

        private BarrierLine _barrierLine;

        public void SpawnBarrierLine()
        {
            _barrierLine = ObjectPool.Instance.GetObject(_barrierLinePrefab);
            _barrierLine.SpawnRandomBareier();
            _barrierLine.transform.SetParent(transform);
            _barrierLine.transform.position = _barrierLinePosition.transform.position;
        }

        public void Reset()
        {
            Destroyed?.Invoke(this);
            _barrierLine.Reset();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<VehicleController>())
            {
                TriggeredEnter?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<VehicleController>())
            {
                TriggeredExit?.Invoke(this);    
            }
        }
    }
}
