using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class BulletCollisionMechanics
    {
        private readonly IAtomicValue<float> damage;
        private readonly IAtomicVariable<bool> isBulletAlive;
        
        public BulletCollisionMechanics(IAtomicValue<float> damage, IAtomicVariable<bool> isBulletAlive)
        {
            this.damage = damage;
            this.isBulletAlive = isBulletAlive;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if(collider.TryGetComponent(out AtomicObject atomicObject))
            {
                if(atomicObject.TryGet(ObjectApi.TakeDamageEvent, out IAtomicEvent<float> takeDamageEvent))
                {
                    takeDamageEvent.Invoke(damage.Value);
                }
            }
            
            isBulletAlive.Value = false;
        }
    }
}