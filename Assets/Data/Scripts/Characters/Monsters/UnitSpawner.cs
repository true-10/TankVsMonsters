using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TankVsMonsters.Characters
{
    public class UnitSpawner : MonoBehaviour
    {
        [Inject]
        private BattleUnitManager unitManager;

        [SerializeField]
        private Transform tankSpawnPoint;
        [SerializeField]
        private GameObject tankPrefab;
        [SerializeField]
        private FollowTransform tankFollower;
        [SerializeField]
        private Transform monsterRoot;
        [SerializeField]
        private List<Transform> spawnPoints;

        private MonsterStaticDataManager monsterStaticDataManager;
        private List<MonsterBehaviour> monsters;
        private TankBehaviour tank;

        private void Awake()
        {
            monsters = new();
            monsterStaticDataManager = new();
        }

        private void Start()
        {
            RealSpawnOnStart(); 
            SpawnTank();

            unitManager.Init(monsters, tank);
            unitManager.OnUnitDeath += OnUnitDeath;
        }

        private void OnDestroy()
        {
            unitManager.OnUnitDeath += OnUnitDeath;
        }

        private void OnUnitDeath(BattleUnit unit)
        {
            if (unit is MonsterBehaviour)
            {
                PoolSpawn();
            }
        }

        public void RealSpawnOnStart()
        {
            for (int i = 0; i < monsterStaticDataManager.MaxCount; i++)
            {
                RealSpawnRandomMonster();
            }
        }

        public void PoolSpawn()
        {
            var unit = unitManager.GetFreeMonster();
            if (unit == null)
            {
                return;
            }
            var spawnPoint = GetRandomSpawnPoint();

            unit.transform.position = spawnPoint.position;
            unit.ResetValues();

        }
        public void RealSpawnRandomMonster()
        {
            var randomStatic = monsterStaticDataManager.GetRandomMonster();
            var spawnPoint = GetRandomSpawnPoint();
            Vector3 randomOffset = Vector3.one * Random.Range(-3f, 3f);
            randomOffset.y = 0f;
            var monsterGO = Instantiate(randomStatic.MonsterPrefab, spawnPoint.position + randomOffset, Quaternion.identity, monsterRoot);
            var monster = monsterGO.GetComponent<MonsterBehaviour>();
            monster.SetStaticData(randomStatic);
            monsters.Add(monster);
        }

        public void SpawnTank()
        {
            var tankGo = Instantiate(tankPrefab, tankSpawnPoint.position, Quaternion.identity, null);
            tank = tankGo.GetComponent<TankBehaviour>();
            tankFollower.SetTarget(tank.transform);
        }


        private Transform GetRandomSpawnPoint()
        {
            var index = Random.Range(0, spawnPoints.Count);
            return spawnPoints[index];
        }

    }
}
