namespace TankVsMonsters
{
    public interface IState
    {
        void Update();
        void FixedUpdate();
        void Enter();
        void Exit();
    }

}
