
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace TankVsMonsters.WeaponSystem
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField]
        private List<TankWeapon> weapons;

        private int currentWeaponIndex = 0;
        private int count => weapons.Count;

        public TankWeapon GetCurrentWeapon() => weapons[currentWeaponIndex];

        public void SwitchToNext(Action<TankWeapon> onSwitch)
        {
            Switch(Next, onSwitch);
        }

        public void SwitchToPrevious(Action<TankWeapon> onSwitch)
        {
            Switch(Previous, onSwitch);
        }

        private void Switch(Action switchDirection, Action<TankWeapon> onSwitch)
        {
            if (count <= 1)
            {
                return;
            }
            var weaponTransform = GetCurrentWeapon().transform;
            ScaleWeapon(weaponTransform, Vector3.zero);
            Next();
            var nextWeapon = GetCurrentWeapon();
            weaponTransform = nextWeapon.transform;
            ScaleWeapon(weaponTransform, Vector3.one);
            onSwitch?.Invoke(nextWeapon);
        }

        private void Next()
        {
            currentWeaponIndex++;
            if (currentWeaponIndex > count - 1)
            {
                currentWeaponIndex = 0;
            }
        }

        private void Previous()
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = count - 1;
            }
        }


        private void ScaleWeapon(Transform weaponTransform, Vector3 scale)
        {
            weaponTransform.DOScale(scale, 0.5f);
        }

    }
}
