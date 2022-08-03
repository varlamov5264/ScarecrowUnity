using UnityEngine;

namespace Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private int _damage = 20;
        [SerializeField] private float _cooldownTime = 0.15f;
        [SerializeField] private float _fireDistance = 100f;
        [SerializeField] private AnimationClip _fireClip;
        [SerializeField] private Transform _bulletSpawn;
        private Animation _animation;
        private Cooldown _cooldown;

        private void Start()
        {
            _animation = GetComponent<Animation>();
            _cooldown = new Cooldown(_cooldownTime, this);
        }

        protected override void Fire()
        {
            _animation.Play(_fireClip.name);
            ObjectFactory.Instance.CreateBullet().transform
                .SetPositionAndRotation(_bulletSpawn.position, _bulletSpawn.rotation);
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _fireDistance))
            {
                if (hit.transform.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(_damage);
                }
            }
        }

        protected override bool FireCondition() => base.FireCondition() && _cooldown.IsReady;
    }
}