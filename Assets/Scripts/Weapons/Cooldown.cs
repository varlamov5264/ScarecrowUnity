using UnityEngine;

namespace Weapons
{
    public class Cooldown
    {
        private float _cooldown;
        private float _fireTime;

        public bool IsReady => _fireTime + _cooldown < Time.timeSinceLevelLoad;

        public Cooldown(float cooldown, Weapon weapon)
        {
            _cooldown = cooldown;
            weapon.onFire += Fire;
        }

        public void Fire()
        {
            _fireTime = Time.timeSinceLevelLoad;
        }
    }
}