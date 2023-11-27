using System.Collections;
using System.Collections.Generic;
using TankVsMonsters.WeaponSystem;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    public class TankBehaviour : BattleUnit
    {
        [SerializeField]
        private WeaponSwitcher weaponSwitcher;
        [SerializeField]
        private float speed = 20f;
        [SerializeField]
        private float rotationSpeed = 20f;
        [SerializeField]
        private float maxHp = 100f;
        [SerializeField, Range(0f, 1f)]
        private float armor = 1f;


        private TankWeapon currentWeapon;

        public void SetWeapon(TankWeapon newWeapon) => currentWeapon = newWeapon;

        public void Start()
        {
            base.Start();
            currentWeapon = weaponSwitcher.GetCurrentWeapon();
            currentHp = maxHp;
        }

        public override void Move(Vector3 direction)
        {
            if (cachedRigidbody == null)
            {
                cachedRigidbody = GetComponent<Rigidbody>();
            }
            var newDirection = cachedRigidbody.transform.forward * direction.z;
            cachedRigidbody.velocity = newDirection * speed;
        }
        public override void Rotate(Vector3 angles)
        {
            var angle = cachedRigidbody.rotation.eulerAngles.y + rotationSpeed * angles.x * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.AngleAxis(angle, cachedRigidbody.transform.up);
            cachedRigidbody.MoveRotation(deltaRotation);
        }

        public override void Attack()
        {
            currentWeapon.Attack();
        }

        public override void Die()
        {
            //spawnFx
            Destroy(gameObject);
            base.Die();
        }

        protected override float GetArmorValue() => 1f - armor;
        public void SwitchWeaponToNext() => weaponSwitcher.SwitchToNext((weapon) => SetWeapon(weapon));
        public void SwitchWeaponToPrevious() => weaponSwitcher.SwitchToPrevious((weapon) => SetWeapon(weapon));
    }
}
