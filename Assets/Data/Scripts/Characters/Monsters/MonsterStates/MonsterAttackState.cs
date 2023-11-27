using UnityEngine;

namespace TankVsMonsters.Characters
{
    public class MonsterAttackState : MonsterBaseState
    {
        private GameObject target;

        public MonsterAttackState(MonsterBehaviour enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public override void Enter()
        {
            base.Enter();
            monster.AttackStateLogicInsstance.EnterLogic();
        }

        public override void Exit()
        {
            base.Exit();
            monster.AttackStateLogicInsstance.ExitLogic();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            monster.AttackStateLogicInsstance.FixedUpdateLogic();
        }

        public override void Update()
        {
            base.Update();
            monster.AttackStateLogicInsstance.UpdateLogic();
        }
    }

}
