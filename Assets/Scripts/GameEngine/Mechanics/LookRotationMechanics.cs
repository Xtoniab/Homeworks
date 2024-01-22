using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class LookRotationMechanics
    {
        private readonly Transform transform;
        private readonly IAtomicValue<Vector3> lookDirection;
        
        public LookRotationMechanics(Transform transform, IAtomicValue<Vector3> lookDirection)
        {
            this.transform = transform;
            this.lookDirection = lookDirection;
        }
        
        public void Update()
        {
            if (lookDirection.Value != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection.Value);
            }
        }
    }
}