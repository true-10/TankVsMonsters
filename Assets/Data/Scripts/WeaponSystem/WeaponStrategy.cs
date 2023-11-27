using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField]
        protected float damage;
        [SerializeField]
        protected float speed;
        [SerializeField]
        protected float fireRateSec;
        [SerializeField]
        protected GameObject bulletPrefab;

        public float FireRateSec => fireRateSec; 

        public virtual void Init()
        {

        }

        public abstract void Fire(Transform bulletStartPoint, Transform bulletRoot);
    }
}
