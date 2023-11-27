using TankVsMonsters.Characters;
using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject hitPrefab;

        private Rigidbody cachedRigidbody;
        private float speed;
        private float damage;

        public void SetSpeed(float speed) => this.speed = speed;
        
        public void SetDamage(float damage) => this.damage = damage;
        
        protected void Start() => cachedRigidbody = GetComponent<Rigidbody>();

        public void Move() => cachedRigidbody.velocity = cachedRigidbody.transform.forward * speed;

        private void FixedUpdate() => Move();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(damage);
                
            }
            if (hitPrefab != null)
            {
                var contact = collision.contacts[0];
                var hitVfx = Instantiate(hitPrefab, contact.point, Quaternion.LookRotation(contact.normal, Vector3.up) );
                DestroyVFXGameObject(hitVfx);
            }
            Destroy(gameObject);
        }

        private void DestroyVFXGameObject(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}
