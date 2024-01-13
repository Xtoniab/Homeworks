using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<GameObject> OnFire;
        
        [SerializeField] private float fireCooldown = 1f;

        private GameObject target;
        private float currentTime;
        
        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void ResetCooldown()
        {
            this.currentTime = this.fireCooldown;
        }

        public void FixedTick()
        {
            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                OnFire?.Invoke(this.target);
                this.currentTime += this.fireCooldown;
            }
        }
    }
}