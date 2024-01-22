using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using Systems;
using UnityEngine;

namespace GameEngine.Actions
{
    [Serializable]
    public class SpawnBulletAction: IAtomicAction
    {
        private BulletSystem bulletSystem;
        private Transform firePoint;
        private IAtomicEvent spawnBulletEvent;
        
        public void Compose(BulletSystem bulletSystem, Transform firePoint, IAtomicEvent spawnBulletEvent)
        {
            this.bulletSystem = bulletSystem;
            this.firePoint = firePoint;
            this.spawnBulletEvent = spawnBulletEvent;
        }
        
        [Button]
        public void Invoke()
        {
            bulletSystem.SpawnBullet(firePoint.position, firePoint.rotation);
            spawnBulletEvent.Invoke();
        }
    }
}