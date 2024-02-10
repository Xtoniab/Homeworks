using Atomic.Elements;
using Atomic.Objects;
using CustomPhysics;
using GameEngine.Actions;
using UnityEngine;

namespace GameEngine.Components
{
    public class DamageFirstTargetInFrontAreaAction: IAtomicAction<int>
    {
        private Transform transform;
        private LayerMask layerMask;
        private IAtomicValue<float> radius;
        private IAtomicAction<AtomicObject> dealDamageAction;
        
        public void Compose(Transform transform, IAtomicValue<float> radius, DealDamageAction dealDamageAction, int layerMask)
        {
            this.transform = transform;
            this.layerMask = layerMask;
            this.radius = radius;
            this.dealDamageAction = dealDamageAction;
        }
        
        public void Invoke(int damage)
        {
            if (PhysicsExtensions.HalfSphereCast(transform, transform.forward, radius.Value, out var hit, 0, layerMask))
            {
                dealDamageAction.Invoke(hit.transform.GetComponent<AtomicObject>());
            }
        }
    }
}