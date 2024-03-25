using TMPro;
using UnityEngine;


namespace Assets.Scripts.GameLogic
{
    public class GameOver: MonoBehaviour
    {
        [SerializeField] private VehicleController car;
        [SerializeField] private CarReset _carReset;
        [SerializeField] private PointsAccumulation _pointsAccumulation;
        [SerializeField] private TMP_Text _textGameOver;

        private void OnEnable()
        {
            car.BarrierTriger += Car_BarrierTriger;
            _textGameOver.gameObject.SetActive(false);
        }

        private void Car_BarrierTriger()
        {
            Debug.Log("GameOver");
            _textGameOver.gameObject.SetActive(true);
            Invoke(nameof(TextGameOverOff), 1.5f);
            _carReset.ResetCar();
            _pointsAccumulation.PointReset();
        }

        private void TextGameOverOff()
        {
            _textGameOver.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            car.BarrierTriger -= Car_BarrierTriger;
        }
    }
}
