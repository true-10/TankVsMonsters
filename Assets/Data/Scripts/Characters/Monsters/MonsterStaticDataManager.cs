using System.Collections.Generic;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    public sealed class MonsterStaticDataManager
    {
        public readonly List<MonsterStaticData> MonsterStaticDatas;
        public readonly int MaxCount;

        public MonsterStaticDataManager()
        {
            var data = MonsterStaticDataLoader.LoadMonsterStaticData();
            MonsterStaticDatas = data.GetData();
            MaxCount = data.MaxCount;
        }

        public MonsterStaticData GetRandomMonster()
        {
            int randomIndex = Random.Range(0, MonsterStaticDatas.Count);
            return MonsterStaticDatas[randomIndex];
        }
    }
}
