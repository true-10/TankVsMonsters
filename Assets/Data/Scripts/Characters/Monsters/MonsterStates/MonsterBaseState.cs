namespace TankVsMonsters.Characters
{
    public class MonsterBaseState : IState
    {
        protected MonsterBehaviour monster;
        protected StateMachine stateMachine;

        public MonsterBaseState(MonsterBehaviour enemy, StateMachine stateMachine)
        {
            this.monster = enemy;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Update()
        {

        }
    }
}
