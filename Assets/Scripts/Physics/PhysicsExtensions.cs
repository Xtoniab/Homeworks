using UnityEngine;

namespace CustomPhysics
{
    public class PhysicsExtensions
    {
        public static bool HalfSphereCast(Transform transform, Vector3 direction, float castRadius, out RaycastHit hit, float maxDistance, LayerMask layerMask)
        {
            var hasHit = Physics.SphereCast(transform.position, castRadius, direction, out hit, maxDistance, layerMask);

            if (!hasHit)
            {
                return false;
            }
            
            var directionToHit = hit.point - transform.position; 
            
            return Vector3.Angle(transform.forward, directionToHit) <= 90f;
        }
    }
}