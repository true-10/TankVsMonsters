using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    public class MonsterWeapon : AbstractWeaponBehaviour
    {
        private float timeToFire;

        public override void Attack()
        {
            timeToFire += Time.deltaTime;

            if (timeToFire > strategy.FireRateSec)
            {
                strategy.Fire(bulletStartPosition, bulletRoot);
                timeToFire = 0f;
            }
        }

    }
}
