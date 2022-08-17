using UnityEngine;

namespace Weapons
{
    public abstract class WeaponBall : Weapon
    {
        [SerializeField] private float _dropForce;
        private bool _droped;

        protected override void Fire()
        {
            DropFromHand();
            _droped = true;
            _isAvailible = false;
            GetComponent<Rigidbody>().AddForce(transform.forward - transform.up * _dropForce);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_droped)
            {
                if (collision.gameObject.CompareTag(Constants.EnemyTag))
                {
                    Damage(collision);
                }
                Destroy(gameObject);
            }
        }

        public abstract void Damage(Collision collision);
    }
}