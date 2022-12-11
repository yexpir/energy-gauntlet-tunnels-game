using UTN_TP.GameManagement;

namespace UTN_TP.Character
{
    public class PlayerHealth : Health, IDamageable, IKillable
    {
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            print(CurrentHealth);
            if(CurrentHealth <= 0) Die();
        }
        public void Die() => GameManager.Instance.UpdateGameState(GameState.Die);
    }
}