using System;
using TankVsMonsters.WeaponSystem;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public class BattleUnit : MonoBehaviour, IDamagable, IMovable
    {
        protected Rigidbody cachedRigidbody;

        protected float currentHp;
        protected BattleUnitManager unitManager;

        protected void Start()
        {
            cachedRigidbody = GetComponent<Rigidbody>();
        }

        public void SetUnitManager(BattleUnitManager unitManager) => this.unitManager = unitManager;
        public virtual void Die() => unitManager?.OnUnitDeath?.Invoke(this);
        public virtual void Move(Vector3 direction) { }
        public virtual void Rotate(Vector3 angles) { }
        public virtual void Attack() { }
        protected virtual float GetArmorValue() => 1f;

        public virtual void ResetValues() { }

        public void TakeDamage(float damage)
        {
            currentHp -= damage * GetArmorValue();

            if (currentHp <= 0)
            {
                Die();
            }
        }

        protected void DestroyVFXGameObject(GameObject vfx)
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
