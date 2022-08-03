using UnityEngine;

namespace Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private int _damage = 20;
        [SerializeField] private AnimationClip _fireClip;
        [SerializeField] private Transform _bulletSpawn;
        private Animation _animation;

        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        protected override void Fire()
        {
            _animation.Play(_fireClip.name);
            ObjectLibrary.Instance.CreateBullet().transform
                .SetPositionAndRotation(_bulletSpawn.position, _bulletSpawn.rotation);
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 100))
            {
                if (hit.transform.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(_damage);
                }
            }
        }
    }
}