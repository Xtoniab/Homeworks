
using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using Systems;
using UnityEngine;

namespace GameEngine.Actions
{
    [Serializable]
    public class FireAction: IAtomicAction
    {
        private BulletSystem bulletSystem;
        private Transform firePoint;
        
        public FireAction(BulletSystem bulletSystem, Transform firePoint)
        {
            this.bulletSystem = bulletSystem;
            this.firePoint = firePoint;
        }
        
        [Button]
        public void Invoke()
        {
            bulletSystem.SpawnBullet(firePoint.position, firePoint.rotation);
        }
    }
}