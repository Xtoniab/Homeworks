using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        private const float TargetPositionToleranceSqr = 0.25f * 0.25f;
        
        public bool IsReached => this.isReached;
        
        private Vector2 destination;

        private bool isReached;
        
        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.isReached = false;
        }
        
        public Vector2 GetMoveDirection()
        {
            if (this.isReached)
            {
                return Vector2.zero;
            }
            
            var vector = this.destination - (Vector2) this.transform.position;
            if (vector.sqrMagnitude <= TargetPositionToleranceSqr)
            {
                this.isReached = true;
                return Vector2.zero;
            }

            return vector.normalized;
        }
    }
}