using System;
using UnityEngine;

namespace ShootEmUp
{
    public class ShipComponent : MonoBehaviour
    {
        public event Action OnDeath;

        [SerializeField] private TeamComponent team;
        [SerializeField] private WeaponComponent weapon;
        [SerializeField] private HealthComponent health;
        [SerializeField] private MoveComponent move;

        public void Construct(BulletSystem bulletSystem)
        {
            this.weapon.Construct(bulletSystem, this.team.TeamTag, fireCondition: () => this.health.IsAlive());
            this.move.Construct(moveCondition: () => this.health.IsAlive());
        }

        private void OnEnable()
        {
            this.health.OnDeath += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.health.OnDeath -= this.OnCharacterDeath;
        }

        public void Move(Vector2 direction)
        {
            move.Move(direction * Time.fixedDeltaTime);
        }

        public void FireForward()
        {
            weapon.Fire();
        }
        
        public void FireTarget(GameObject target)
        {
            weapon.Fire(target);
        }

        public void Reset()
        {
            health.Reset();
        }

        private void OnCharacterDeath()
        {
            this.OnDeath?.Invoke();
        }
    }
}