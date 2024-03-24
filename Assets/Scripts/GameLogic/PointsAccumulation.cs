using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class PointsAccumulation: MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;

        [SerializeField] private VehicleController car;

        private int point = 0;

        private void Awake()
        {
            car.RoadSectionTriger += Car_RoadSectionTriger; ;
        }

        private void Car_RoadSectionTriger()
        {
            point++;
            _textMeshPro.text = $"{point}";
            Debug.Log($"{point}");
        }
    }
}
