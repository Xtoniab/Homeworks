using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class BulletCollisionMechanics
    {
        private readonly IAtomicValue<int> damage;
        private readonly IAtomicVariable<bool> hitTarget;
        private readonly IAtomicAction<AtomicObject> dealDamageAction;

        public BulletCollisionMechanics(
            IAtomicValue<int> damage,
            IAtomicVariable<bool> hitTarget,
            IAtomicAction<AtomicObject> dealDamageAction)
        {
            this.damage = damage;
            this.hitTarget = hitTarget;
            this.dealDamageAction = dealDamageAction;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (hitTarget.Value)
            {
                return;
            }

            if (collider.TryGetComponent(out AtomicObject atomicObject))
            {
               dealDamageAction.Invoke(atomicObject);
            }

            hitTarget.Value = true;
        }
    }
}