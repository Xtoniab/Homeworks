using Atomic.Elements;
using Atomic.Objects;
using GameEngine;
using GameEngine.Actions;
using GameEngine.Components;
using GameEngine.Mechanics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Objects
{
    public class Bullet: AtomicObject
    {
        [Get(HealthAPI.IsAlive), SerializeField] private AtomicFunction<bool> isAlive = new();
        [SerializeField] private AtomicValue<int> damage = new(1);
        [SerializeField] private AtomicVariable<bool> hitTarget;
        [SerializeField] private DealDamageAction dealDamageAction = new();
        [SerializeField] private MoveComponent moveComponent = new();
        [SerializeField] private LifetimeComponent lifetimeComponent = new();
        
        private BulletCollisionMechanics bulletCollisionMechanics;
        
        public override void Compose()
        {
            base.Compose();
            
            dealDamageAction.Compose(damage);
            lifetimeComponent.Compose();
            
            moveComponent.Compose();
            moveComponent.MoveEnabled.Append(lifetimeComponent.IsAlive);
            
            isAlive.Compose(() => !hitTarget.Value && lifetimeComponent.IsAlive.Value);

            bulletCollisionMechanics = new BulletCollisionMechanics(damage, hitTarget, dealDamageAction);
        }
        
        public void Reset()
        {
            hitTarget.Value = false;
            lifetimeComponent.Reset();
        }
        
        private void FixedUpdate()
        {
            moveComponent.FixedUpdate();
            lifetimeComponent.FixedUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            bulletCollisionMechanics.OnTriggerEnter(other);
        }

        private void OnDestroy()
        {
            hitTarget?.Dispose();
            lifetimeComponent?.Dispose();
        }
    }
}