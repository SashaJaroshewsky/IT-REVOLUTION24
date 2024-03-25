using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Road
{
    public class RoadC : MonoBehaviour
    {
        [SerializeField] private RoadSection _roadSectionRpefab;
        [SerializeField] private List<RoadSection> _roadSections;

        public Transform CarReloadScene => _roadSections[_roadSections.Count - 1].CarSpawn;

        private void OnEnable()
        {
            _roadSections = new List<RoadSection>();
            //ObjectPool.Instance.CreateFreeObjects(_roadSectionRpefab, 2);
            AddSelectionToRoad();
        }

        public void AddSelectionToRoad()
        {
            RoadSection roadSection = ObjectPool.Instance.GetObject(_roadSectionRpefab);
            roadSection.transform.SetParent(this.gameObject.transform);
            roadSection.transform.position = GetSpawnPosition();
            roadSection.SpawnBarrierLine();
            roadSection.TriggeredEnter += AddSelectionToRoad;
            roadSection.TriggeredExit += RemoveSelectionInRoad;
            _roadSections.Add(roadSection);
        }

        public void RemoveSelectionInRoad(RoadSection roadSection)
        {
            roadSection.TriggeredEnter -= AddSelectionToRoad;
            roadSection.TriggeredExit -= RemoveSelectionInRoad;
            roadSection.Reset();
            _roadSections.Remove(roadSection);
        }
        private Vector3 GetSpawnPosition()
        {
            if (_roadSections.Count == 0 )
            {
                return new Vector3(0, 0, 0);
            }
            return _roadSections[_roadSections.Count-1].transform.position + new Vector3(400, 0, 0);
        }
    }
}
