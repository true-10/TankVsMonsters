using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankVsMonsters.Characters
{
    public static class MonsterStaticDataLoader
    {
        private const string path = "MonstersStaticData_";

        public static MonstersStaticDataSO LoadMonsterStaticData()
        {
            return Resources.Load<MonstersStaticDataSO>(path);
        }
    }
}
