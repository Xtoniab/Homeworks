using System.Collections.Generic;
using Atomic.Elements;
using GameEngine;
using Objects;
using UnityEngine;

namespace Systems
{
    public class BulletSystem : MonoBehaviour
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private BulletSpawner bulletSpawner;

        private readonly List<Bullet> activeBullets = new();
        
        public void SpawnBullet(Vector3 position, Quaternion rotation)
        {
            var newBullet = bulletSpawner.Spawn(position, rotation);
            activeBullets.Add(newBullet);
        }

        private void FixedUpdate()
        {
            CleanupDeadBullets();
        }

        private void CleanupDeadBullets()
        {
            // OpTiMiZaTiOn :D
            for (var i = activeBullets.Count - 1; i >= 0; i--)
            {
                var bullet = activeBullets[i];
                if (bullet.Get<IAtomicValue<bool>>(ObjectApi.IsAlive).Value == false)
                {
                    activeBullets.RemoveAt(i);
                    bulletPool.Pool(bullet);
                }
            }
        }
    }
}