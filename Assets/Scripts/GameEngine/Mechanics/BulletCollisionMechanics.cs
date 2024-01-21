using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class BulletCollisionMechanics
    {
        private readonly IAtomicValue<int> damage;
        private readonly IAtomicVariable<bool> hitTarget;

        public BulletCollisionMechanics(IAtomicValue<int> damage, IAtomicVariable<bool> hitTarget)
        {
            this.damage = damage;
            this.hitTarget = hitTarget;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (hitTarget.Value)
            {
                return;
            }

            if (collider.TryGetComponent(out AtomicObject atomicObject))
            {
                if (atomicObject.TryGet(ObjectApi.TakeDamageAction, out IAtomicAction<int> takeDamageAction))
                {
                    takeDamageAction.Invoke(damage.Value);
                }
            }

            hitTarget.Value = true;
        }
    }
}