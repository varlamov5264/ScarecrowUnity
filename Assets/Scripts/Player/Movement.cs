using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : InputMotion
    {
        private CharacterController _character;
        private float _gravityTimer;

        protected override string XAxisName => Constants.MovementX;

        protected override string YAxisName => Constants.MovementY;

        private void Start()
        {
            _character = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var axis = GetAxis();
            if (_character.isGrounded)
                _gravityTimer = 0;
            else
                _gravityTimer -= Constants.Gravity * Time.deltaTime;
            var move = transform.right * axis.x +
                       transform.forward * axis.y -
                       Vector3.up * _gravityTimer * Time.deltaTime;
            _character.Move(move);
        }
    }
}