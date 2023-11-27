using UnityEngine;

namespace TankVsMonsters.Characters
{
    [System.Serializable]
    public class CharacterStaticData
    {
        public float MaxHealth;
        public float Armor;//0..1
        public GameObject PrefabOnDeathFx;
    }
}
