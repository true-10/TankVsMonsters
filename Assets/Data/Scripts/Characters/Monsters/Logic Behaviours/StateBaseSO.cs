using UnityEngine;

namespace TankVsMonsters.Characters
{
    public class StateBaseSO : ScriptableObject
    {
        public virtual void EnterLogic()
        {

        }

        public virtual void ExitLogic()
        {
            ResetValues();
        }

        public virtual void FixedUpdateLogic()
        {

        }

        public virtual void UpdateLogic()
        {

        }

        public virtual void ResetValues()
        {

        }

    }
}
