using UnityEngine;

namespace Weapons
{
    public class Waterball : WeaponBall
    {
        [SerializeField] private int _water;

        public override void Damage(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IWaterReceivable waterReceivable))
            {
                waterReceivable.Water(_water);
            }
        }
    }
}