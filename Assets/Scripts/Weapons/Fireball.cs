using UnityEngine;

namespace Weapons
{
    public class Fireball : WeaponBall
    {
        public override void Damage(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IFlammable flammable))
            {
                flammable.Burn();
            }
        }
    }
}