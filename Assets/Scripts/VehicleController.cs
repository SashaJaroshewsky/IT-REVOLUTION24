using Assets.Scripts.Road;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private WheelCollider _frontRight;
        [SerializeField] private WheelCollider _frontLeft;
        [SerializeField] private WheelCollider _backRight;
        [SerializeField] private WheelCollider _backLeft;

        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxTurnAngle;

        [SerializeField] private Transform _frontRightTransform;
        [SerializeField] private Transform _frontLeftTransform;
        [SerializeField] private Transform _backRightTransform;
        [SerializeField] private Transform _backLeftTransform;

        [SerializeField] private Vector3 _centerOfMass;

        private float _currentAcceleration = 0;
        private float _currentTurnAngle = 0;

        public event Action BarrierTriger;
        public event Action RoadSectionTriger;

        [SerializeField] private Button buttonL;
        [SerializeField] private Button buttonR;

        private void Awake()
        {
            GetComponent<Rigidbody>().centerOfMass = _centerOfMass;
            //buttonL.OnPointerDown += ButtonLeftDown;
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            DriveVehicle();
            WheelTurn();
            _currentAcceleration += _acceleration;
        }


       

        public void ButtonLeftDown()
        {
            _currentTurnAngle -= 1f * _maxTurnAngle;
        }

        public void ButtonLeftUp()
        {
            _currentTurnAngle = 0f;
        }

        public void ButtonRightDown()
        {
            _currentTurnAngle += 1f * _maxTurnAngle;
        }
        public void ButtonRightUp()
        {
            _currentTurnAngle = 0f;
        }

        private void DriveVehicle()
        {
            _frontRight.motorTorque = _currentAcceleration;
            _frontLeft.motorTorque = _currentAcceleration;
        }

        private void WheelTurn()
        {
            _frontLeft.steerAngle = _currentTurnAngle;
            _frontRight.steerAngle = _currentTurnAngle;

            UpdateTransform(_frontLeft, _frontLeftTransform);
            UpdateTransform(_frontRight, _frontRightTransform);
            UpdateTransform(_backLeft, _backLeftTransform);
            UpdateTransform(_backRight, _backRightTransform);
        }

        private void UpdateTransform(WheelCollider col, Transform trans)
        {
            Vector3 position;
            Quaternion rotation;
            col.GetWorldPose(out position, out rotation);

            trans.position = position;
            trans.rotation = rotation;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<Road.Barrier>())
            {
                BarrierTriger?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<RoadSection>())
            {
                RoadSectionTriger?.Invoke();
            }
        }


    }
}
