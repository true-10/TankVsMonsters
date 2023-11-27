using UnityEngine;

namespace TankVsMonsters.Characters
{
    [CreateAssetMenu(fileName = "SingleMonsterStaticData", menuName = "TankVsMonsters/Monsters/SingleMonsterStaticData")]
    public class SingleMonsterStaticDataSO : ScriptableObject 
    {
        public MonsterStaticData MonsterStaticData;
    }
}
