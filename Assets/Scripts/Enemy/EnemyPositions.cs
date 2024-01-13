using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;
        
        public bool HasAvailableAttackPositions => availableAttackPositions.Count > 0;
        
        private HashSet<Transform> availableAttackPositions;
        
        private void Awake()
        {
            availableAttackPositions = new HashSet<Transform>(attackPositions);
        }
        
        public Transform RandomSpawnPosition()
        {
            return this.spawnPositions.PickRandomElement();
        }

        public Transform AcquireRandomAttackPosition()
        {
            if (availableAttackPositions.Count == 0)
            {
                Debug.LogError("No available attack positions!");
                return null;
            }
            
            var attackPosition = availableAttackPositions.PickRandomElement();
            availableAttackPositions.Remove(attackPosition);

            return attackPosition;
        }
        
        public void ReleaseAttackPosition(Transform attackPosition)
        {
            if (attackPosition != null)
            {
                availableAttackPositions.Add(attackPosition);
            }
        }
    }
}