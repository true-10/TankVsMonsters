
using UnityEngine;

namespace TankVsMonsters.Characters
{
    [CreateAssetMenu(fileName = "IdleGoToTankLogic", menuName = "TankVsMonsters/Monsters/States/IdleGoToTankLogic")]
    public class IdleGoToTankLogic : MonsterIdleLogicBaseSO
    {
        public override void FixedUpdateLogic()
        {
            if (monsterBehaviour == null || tank == null)
            {
                return;
            }
            base.UpdateLogic();
            var direction = (tank.transform.position - monsterBehaviour.transform.position).normalized;
            monsterBehaviour.Move(direction);
        }
    }
}

