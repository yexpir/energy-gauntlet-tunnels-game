using System;
using UnityEngine;

namespace UTN_TP.Character.Player
{
    public class PunchBeahviour : MonoBehaviour
    {
        PlayerData _data;
        int _damage => PlayerData.Instance.punchDamage;
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            var enemy = other.GetComponent<IDamageable>();
            enemy?.TakeDamage(_damage);
        }
    }
}
