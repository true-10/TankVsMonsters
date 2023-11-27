using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    [CreateAssetMenu(fileName = "MonsterIdleStateBaseSO", menuName = "TankVsMonsters/Monsters/States/MonsterIdleStateBaseSO")]
    public class MonsterIdleLogicBaseSO : StateBaseSO
    {
        protected GameObject tank;
        protected MonsterBehaviour monsterBehaviour;

        public  void Init(MonsterBehaviour monsterBehaviour)
        {
            this.monsterBehaviour = monsterBehaviour;

            tank = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
