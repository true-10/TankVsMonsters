using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    [CreateAssetMenu(fileName = "MonsterSimpleAttackLogicSO", menuName = "TankVsMonsters/Monsters/States/MonsterSimpleAttackLogicSO")]
    public class MonsterSimpleAttackLogicSO : MonsterAttackStateBaseSO
    {

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            monsterBehaviour.Attack();
        }

    }
}
