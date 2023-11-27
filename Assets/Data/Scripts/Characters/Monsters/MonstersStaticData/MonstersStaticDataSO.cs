using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TankVsMonsters.Characters
{
    [CreateAssetMenu(fileName = "MonstersStaticData", menuName = "TankVsMonsters/Monsters/MonsterStaticData")]
    public class MonstersStaticDataSO : ScriptableObject
    {
        public int MaxCount = 10;
        public List<SingleMonsterStaticDataSO> monstersStaticDatas;

        public List<MonsterStaticData> GetData()
        {
            return monstersStaticDatas.Select(m => m.MonsterStaticData).ToList();
        }
    }
}
