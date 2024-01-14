using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveAgent : MonoBehaviour
    {
        private const float TargetPositionToleranceSqr = 0.25f * 0.25f;
        
        public bool IsReached { get; private set; }
        
        private Vector2 destination;
        
        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.IsReached = false;
        }
        
        public Vector2 GetMoveDirection()
        {
            if (this.IsReached)
            {
                return Vector2.zero;
            }
            
            var vector = this.destination - (Vector2) this.transform.position;
            if (vector.sqrMagnitude <= TargetPositionToleranceSqr)
            {
                this.IsReached = true;
                return Vector2.zero;
            }

            return vector.normalized;
        }
    }
}