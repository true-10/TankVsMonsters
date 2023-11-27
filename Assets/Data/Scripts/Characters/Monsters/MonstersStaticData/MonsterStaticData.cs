using UnityEngine;

namespace TankVsMonsters.Characters
{
    [System.Serializable]
    public class MonsterStaticData : CharacterStaticData
    {
        public GameObject MonsterPrefab;
        public float MoveSpeed;
        public float Damage;
        public MonsterType MonsterType;

    }

    public enum MonsterType 
    { 
        Claw = 1,
        Range = 2,
    }

}
