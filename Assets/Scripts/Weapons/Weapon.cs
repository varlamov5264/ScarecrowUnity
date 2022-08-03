using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : Item
    {
        [SerializeField] private float _cooldown;
        private float _timer;

        private void Update()
        {
            if (InHand)
            {
                _timer = Mathf.MoveTowards(_timer, 0, Time.deltaTime);
                if (Input.GetKeyDown(_interactKey) && _timer == 0)
                {
                    Fire();
                    _timer = _cooldown;
                }
            }
        }

        protected abstract void Fire();
    }
}