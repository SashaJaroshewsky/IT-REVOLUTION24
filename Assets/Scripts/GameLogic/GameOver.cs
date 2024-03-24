using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameLogic
{
    public class GameOver: MonoBehaviour
    {
        [SerializeField] private VehicleController car;
        private void Awake()
        {
            car.BarrierTriger += Car_BarrierTriger;
        }

        private void Car_BarrierTriger()
        {
            Debug.Log("GameOver");

            car.BarrierTriger -= Car_BarrierTriger;
            //ObjectPool.Instance.Dispose();
            SceneManager.LoadScene(0);
        }
    }
}
