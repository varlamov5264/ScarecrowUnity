using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : InputMotion
    {
        private CharacterController _character;

        protected override string XAxisName => Constants.MovementX;

        protected override string YAxisName => Constants.MovementY;

        private void Start()
        {
            _character = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var axis = GetAxis();
            var move = transform.right * axis.x +
                       transform.forward * axis.y +
                       Vector3.up * Constants.Gravity * Time.deltaTime;
            _character.Move(move);
        }
    }
}