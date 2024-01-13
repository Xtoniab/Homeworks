using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action OnDeath;
        
        [SerializeField] private int maxHitPoints;

        private int hitPoints;

        private void Awake()
        {
            this.hitPoints = this.maxHitPoints;
        }

        public bool IsAlive() {
            return this.hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                this.OnDeath?.Invoke();
            }
        }

        public void Reset()
        {
            this.hitPoints = this.maxHitPoints;
            OnDeath = null;
        }
    }
}