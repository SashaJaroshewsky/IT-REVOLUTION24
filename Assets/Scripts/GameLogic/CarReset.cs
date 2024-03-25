using UnityEngine;
using RoadC = Assets.Scripts.Road.RoadC;

namespace Assets.Scripts.GameLogic
{
    public class CarReset: MonoBehaviour
    {
        [SerializeField] private RoadC _road;
        [SerializeField] private VehicleController _vehicleController;

        public void ResetCar()
        {
            _vehicleController.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _vehicleController.SetCarCurrentAcceleration();
            _vehicleController.SetCarPosition(_road.CarReloadScene);
        }
    }
}
