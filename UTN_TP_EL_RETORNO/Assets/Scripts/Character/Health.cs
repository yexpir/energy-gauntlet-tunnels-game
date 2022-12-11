using System;
using UnityEngine;

namespace UTN_TP.Character
{
    public abstract class Health : MonoBehaviour
    {
        [Range(100, 300)]
        public int maxHealth;
        [SerializeField] int _health = 100;

        void OnValidate() => CurrentHealth = _health;

        public int CurrentHealth
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, maxHealth);
        }
    }
}