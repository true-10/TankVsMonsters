using System;
using System.Collections.Generic;
using System.Linq;

namespace TankVsMonsters.Characters
{
    public sealed class BattleUnitManager
    {
        public Action<BattleUnit>  OnUnitDeath { get; set; }

        public TankBehaviour Tank => tank;

        private List<MonsterBehaviour> monsters;
        private TankBehaviour tank;

        public void Init(List<MonsterBehaviour> monsters, TankBehaviour tank)
        {
            this.tank = tank;
            this.monsters = monsters;

            tank.SetUnitManager(this);
            monsters.ForEach(m => m.SetUnitManager(this));
        }

        public MonsterBehaviour GetFreeMonster()
        {
            return monsters.FirstOrDefault(m => m.gameObject.activeInHierarchy == false);
        }
    }
}
