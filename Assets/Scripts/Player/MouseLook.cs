using UnityEngine;

namespace Player
{
    public class MouseLook : InputMotion
    {
        [SerializeField] private Limits _yRotationLimit = new Limits(-90, 90);
        private Vector3 _currentRotation;

        protected override string XAxisName => Constants.RotationX;

        protected override string YAxisName => Constants.RotationY;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _currentRotation = transform.localEulerAngles;
        }

        private void Update()
        {
            var axis = GetAxis();
            _currentRotation.x = _yRotationLimit.Clamp(_currentRotation.x - axis.y);
            _currentRotation.y += axis.x;
            transform.localEulerAngles = _currentRotation;
        }
    }
}