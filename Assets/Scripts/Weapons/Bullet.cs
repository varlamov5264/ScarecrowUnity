using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 1000;

        private void Update()
        {
            transform.position -= transform.up * _speed * Time.deltaTime;
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}