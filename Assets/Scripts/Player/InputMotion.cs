using UnityEngine;

namespace Player
{
    public abstract class InputMotion : MonoBehaviour
    {
        [SerializeField] private float _speed;

        protected abstract string XAxisName { get; }

        protected abstract string YAxisName { get; }

        protected Vector2 GetAxis() =>
            new Vector2(Input.GetAxis(XAxisName), Input.GetAxis(YAxisName)) * _speed * Time.deltaTime;
    }
}