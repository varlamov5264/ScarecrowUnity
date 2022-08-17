using UnityEngine;

namespace Player
{
    public class MouseLook : InputMotion
    {
        [SerializeField] private Transform _rotationYCenter;
        [SerializeField] private Limits _yRotationLimit = new Limits(-90, 90);
        private Vector3 _currentRotationX;
        private Vector3 _currentRotationY;

        protected override string XAxisName => Constants.RotationX;

        protected override string YAxisName => Constants.RotationY;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _currentRotationX = transform.localEulerAngles;
            _currentRotationY = _rotationYCenter.localEulerAngles;
        }

        private void Update()
        {
            var axis = GetAxis();
            _currentRotationX.y += axis.x;
            _currentRotationY.x = _yRotationLimit.Clamp(_currentRotationY.x - axis.y);
            transform.localEulerAngles = _currentRotationX;
            _rotationYCenter.localEulerAngles = _currentRotationY;
        }
    }
}