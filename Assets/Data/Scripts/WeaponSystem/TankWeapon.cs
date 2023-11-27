using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    public class TankWeapon : AbstractWeaponBehaviour
    {
        private float timeToFire;
        private bool firePressed;

        public override void Attack()
        {
            firePressed = true;
        }

        private void Update()
        {
            timeToFire += Time.deltaTime;

            if (timeToFire > strategy.FireRateSec && firePressed)
            {
                strategy.Fire(bulletStartPosition, bulletRoot);
                timeToFire = 0f;
            }

            firePressed = false;
        }
    }
}
