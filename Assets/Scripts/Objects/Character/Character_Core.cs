using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Components;
using Systems;

namespace Objects
{
    [Serializable]
    public class Character_Core: IDisposable
    {
        [Section] public HealthComponent healthComponent = new();
        [Section] public MoveComponent moveComponent = new();
        [Section] public AttackComponent attackComponent = new();
        [Section] public Weapon weapon = new();
        
        public void Compose(BulletSystem bulletSystem)
        {
            healthComponent.Compose();
            attackComponent.Compose();
            weapon.Compose(bulletSystem);

            moveComponent.Let(it =>
            {
                it.Compose();
                it.MoveEnabled.Append(healthComponent.IsAlive);
            });
            
            attackComponent.Let(it =>
            {
                it.CanAttack.Append(healthComponent.IsAlive);
                it.CanAttack.Append(moveComponent.IsMoving.AsNot());
            });
        }

        public void OnEnable()
        {
            healthComponent.OnEnable();
        }

        public void OnDisable()
        {
            healthComponent.OnDisable();
        }

        public void FixedUpdate()
        {
            moveComponent.FixedUpdate();
        }

        public void Dispose()
        {
            healthComponent?.Dispose();
            weapon?.Dispose();
        }
    }
}