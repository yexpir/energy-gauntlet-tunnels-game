using UnityEngine;

namespace UTN_TP.Character
{
    public class EnemyHealth : Health, IDamageable, IKillable
    {
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            print(CurrentHealth);
            if(CurrentHealth <= 0) Die();
        }
        public void Die() => Destroy(gameObject);
    }
}