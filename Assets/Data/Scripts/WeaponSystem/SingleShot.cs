using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "TankVsMonsters/Weapon/Strategies/SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform bulletStartPoint, Transform bulletRoot)
        {
            var bulletGo = Instantiate(bulletPrefab, bulletStartPoint.position, bulletStartPoint.rotation);

            if (bulletGo.TryGetComponent(out BulletBehaviour bulletBehaviour))
            {
                bulletBehaviour.transform.SetParent(bulletRoot);
                bulletBehaviour.SetDamage(damage);
                bulletBehaviour.SetSpeed(speed);
            }
            else
            {
                Destroy(bulletGo);
            }
        }
    }
}
