using System;
using UnityEngine;

namespace ShootEmUp
{
    public class AttackPositionHandle
    {
        public Vector3 Value => attackPosition.position;
        
        private readonly Transform attackPosition;
        private readonly Action<Transform> releaseAction;
        
        public AttackPositionHandle(Transform attackPosition, Action<Transform> releaseAction)
        {
            this.attackPosition = attackPosition;
            this.releaseAction = releaseAction;
        }
        
        public void Release()
        {
            releaseAction?.Invoke(attackPosition);
        }
    }
}