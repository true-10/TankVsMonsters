using System;
using System.Collections;
using UnityEngine;
using TankVsMonsters.WeaponSystem;

namespace TankVsMonsters.Characters
{

    public class MonsterBehaviour : BattleUnit
    {
        public MonsterIdleLogicBaseSO IdleStateLogicInsstance { get; private set; }
        public MonsterAttackStateBaseSO AttackStateLogicInsstance { get; private set; }

      //  [SerializeField]
        //private SingleMonsterStaticDataSO enemyStaticDataSO;
        [SerializeField]
        private TankInRangeTrigger tankInRangeTrigger;
        [SerializeField]
        private MonsterIdleLogicBaseSO idleStateSO;
        [SerializeField]
        private MonsterAttackStateBaseSO attackStateSO;
        [SerializeField]
        private MonsterWeapon weapon;

        private StateMachine stateMachine;
        private MonsterIdleState monsterIdleState;
        private MonsterAttackState monsterAttackState;
        private MonsterStaticData staticData;

        public void SetStaticData(MonsterStaticData staticData) => this.staticData = staticData;

        void Awake()
        {
            IdleStateLogicInsstance = Instantiate(idleStateSO);
            AttackStateLogicInsstance = Instantiate(attackStateSO);
            
            stateMachine = new();
            monsterIdleState = new(this, stateMachine);
            monsterAttackState = new(this, stateMachine);

            stateMachine.Init(monsterIdleState);
        }

        protected void Start()
        {
            base.Start();
            currentHp = staticData.MaxHealth;

            IdleStateLogicInsstance.Init(this);
            AttackStateLogicInsstance.Init(this);

            tankInRangeTrigger.OnEnter += OnEnter;
            tankInRangeTrigger.OnExit += OnExit;
        }

        private void OnDestroy()
        {
            tankInRangeTrigger.OnEnter -= OnEnter;
            tankInRangeTrigger.OnExit -= OnExit;
        }

        void Update()
        {
            stateMachine?.Update();
        }

        void FixedUpdate()
        {
            stateMachine?.FixedUpdate();
        }

        public override void ResetValues()
        {
            currentHp = staticData.MaxHealth;
            gameObject.SetActive(true);
            stateMachine.Init(monsterIdleState);

        }
        
        public override void Die()
        {
            //spawnFx
            var hitVfx = Instantiate(staticData.PrefabOnDeathFx, transform.position, Quaternion.identity);
            DestroyVFXGameObject(hitVfx);

            //Destroy(gameObject);
            gameObject.SetActive(false);
            base.Die();
        }

        public override void Move(Vector3 direction)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            Vector3 position = cachedRigidbody.position + direction * Time.deltaTime * GetSpeedValue();
            cachedRigidbody.Move(position, rotation);
        }

        public override void Attack() => weapon.Attack();

        protected override float GetArmorValue() => 1f - staticData.Armor;

        protected float GetSpeedValue() => staticData.MoveSpeed;

        private void OnExit(TankBehaviour tank)
        {
            if (staticData.MonsterType != MonsterType.Range)
            {
                return;
            }
           stateMachine.SetState(monsterIdleState);
        }

        private void OnEnter(TankBehaviour tank)
        {
            if (staticData.MonsterType != MonsterType.Range)
            {
                return;
            }
            stateMachine.SetState(monsterAttackState);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") )
            {
                stateMachine.SetState(monsterAttackState);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") )
            {
                stateMachine.SetState(monsterIdleState);
            }
        }
    }
}
