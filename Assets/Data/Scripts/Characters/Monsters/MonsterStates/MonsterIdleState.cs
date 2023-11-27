
using UnityEngine;
using Zenject;

namespace TankVsMonsters.Characters
{
    public class MonsterIdleState : MonsterBaseState
    {
        private GameObject target;
        
        public MonsterIdleState(MonsterBehaviour monster, StateMachine stateMachine) : base(monster, stateMachine)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public override void Enter()
        {
            base.Enter();
            monster.IdleStateLogicInsstance.EnterLogic();
        }

        public override void Exit()
        {
            base.Exit();
            monster.IdleStateLogicInsstance.ExitLogic();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            monster.IdleStateLogicInsstance.FixedUpdateLogic();
        }

        public override void Update()
        {
            base.Update();
            monster.IdleStateLogicInsstance.UpdateLogic();
        }
    }

}
