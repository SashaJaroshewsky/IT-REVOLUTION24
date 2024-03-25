using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class PointsAccumulation : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;
        [SerializeField] private VehicleController car;

        private int point = 0;
        public void PointReset() { point = 0; }

        private void OnEnable()
        {
            car.RoadSectionTriger += Car_RoadSectionTriger;
        }

        private void Car_RoadSectionTriger()
        {
            point++;
            _textMeshPro.text = $"{point}";
            Debug.Log($"{point}");
        }

        private void OnDisable()
        {
            car.RoadSectionTriger -= Car_RoadSectionTriger;
        }
    }
}
