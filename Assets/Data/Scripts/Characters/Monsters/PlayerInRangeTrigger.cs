using System;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    public class PlayerInRangeTrigger : MonoBehaviour
    {
        public Action<BattleUnit> OnEnter { get; set; }
        public Action<BattleUnit> OnExit { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out BattleUnit charBehaviour) )
            {
                if (charBehaviour.CompareTag("Player"))
                {
                    OnEnter?.Invoke(charBehaviour);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out BattleUnit charBehaviour))
            {
                if (charBehaviour.CompareTag("Player"))
                {
                    OnExit?.Invoke(charBehaviour);
                }
            }
        }
    }
}
