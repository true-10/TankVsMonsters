namespace TankVsMonsters.WeaponSystem
{
    public interface IDamagable
    {
        void TakeDamage(float damage);

        void Die();
    }
}
