using System;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    public class TankInRangeTrigger : MonoBehaviour
    {
        public Action<TankBehaviour> OnEnter { get; set; }
        public Action<TankBehaviour> OnExit { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out TankBehaviour tankBehaviour) )
            {
                OnEnter?.Invoke(tankBehaviour);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out TankBehaviour tankBehaviour))
            {
                OnExit?.Invoke(tankBehaviour);
            }
        }
    }
}
