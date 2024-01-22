using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Components;
using Systems;

namespace Objects
{
    [Serializable]
    public class Character_Core
    {
        [Section] public HealthComponent healthComponent = new();
        [Section] public MoveComponent moveComponent = new();
        [Section] public WeaponComponent weaponComponent = new();
        
        public void Compose(BulletSystem bulletSystem)
        {
            healthComponent.Compose();
            
            moveComponent.Let(it =>
            {
                it.Compose();
                it.MoveEnabled.Append(healthComponent.IsAlive);
            });

            weaponComponent.Let(it =>
            {
                it.Compose(bulletSystem);
                it.CanFire.Append(healthComponent.IsAlive);
                it.CanFire.Append(moveComponent.IsMoving.AsNot());
            });
        }

        public void OnEnable()
        {
            weaponComponent.OnEnable();
            healthComponent.OnEnable();
        }

        public void OnDisable()
        {
            weaponComponent.OnDisable();
            healthComponent.OnDisable();
        }

        public void FixedUpdate()
        {
            moveComponent.FixedUpdate();
        }
    }
}