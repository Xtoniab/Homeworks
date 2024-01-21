using Atomic.Elements;
using Atomic.Objects;
using GameEngine;
using GameEngine.Components;
using GameEngine.Mechanics;
using UnityEngine;

namespace Objects
{
    public class Bullet: AtomicObject
    {
        [Get(ObjectApi.IsAlive), SerializeField] private AtomicFunction<bool> isAlive = new();
        [SerializeField] private AtomicValue<int> damage = new(1);
        [SerializeField] private AtomicVariable<bool> hitTarget;
        
        [SerializeField] private MoveComponent moveComponent = new();
        [SerializeField] private TimedLifeComponent timedLifeComponent = new();
        
        private BulletCollisionMechanics bulletCollisionMechanics;

        public override void Compose()
        {
            base.Compose();
            
            timedLifeComponent.Compose();
            
            moveComponent.Compose();
            moveComponent.MoveEnabled.Append(timedLifeComponent.IsAlive);
            
            isAlive.Compose(() => !hitTarget.Value && timedLifeComponent.IsAlive.Value);

            bulletCollisionMechanics = new BulletCollisionMechanics(damage, hitTarget);
        }
        
        public void Reset()
        {
            hitTarget.Value = false;
            timedLifeComponent.Reset();
        }
        
        private void FixedUpdate()
        {
            moveComponent.FixedUpdate();
            timedLifeComponent.FixedUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            bulletCollisionMechanics.OnTriggerEnter(other);
        }

        private void OnDestroy()
        {
            hitTarget?.Dispose();
            timedLifeComponent?.Dispose();
        }
    }
}