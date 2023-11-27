using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsMonsters.Characters
{

    [CreateAssetMenu(fileName = "MonsterAttackStateBaseSO", menuName = "TankVsMonsters/Monsters/States/MonsterAttackStateBaseSO")]
    public class MonsterAttackStateBaseSO : StateBaseSO
    {
        protected GameObject tank;
        protected MonsterBehaviour monsterBehaviour;

        public void Init(MonsterBehaviour monsterBehaviour)
        {
            this.monsterBehaviour = monsterBehaviour;

            tank = GameObject.FindGameObjectWithTag("Player");
        }
       
    }
}
