using UnityEngine;

namespace TankVsMonsters.WeaponSystem
{
    public abstract class AbstractWeaponBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected WeaponStrategy strategy;
        [SerializeField]
        protected Transform bulletStartPosition;
        [SerializeField]
        protected Transform bulletRoot;

        protected void Start()
        {
            strategy.Init();
        }

        public abstract void Attack();
    }
}
