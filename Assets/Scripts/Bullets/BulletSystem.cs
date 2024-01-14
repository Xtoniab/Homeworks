using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private BulletCreator bulletCreator;
        
        private readonly HashSet<Bullet> activeBullets = new();

        public void SpawnBullet(BulletSpawnOptions options)
        {
            var bullet = this.bulletCreator.Create(options);

            if (this.activeBullets.Add(bullet))
            {
                bullet.OnHit += this.OnBulletHit;
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (this.activeBullets.Remove(bullet))
            {
                bullet.OnHit -= this.OnBulletHit;
                bullet.PoolSelf();
            }
        }

        private void FixedUpdate()
        {
            RemoveOutOfBoundsBullets();
        }

        private void RemoveOutOfBoundsBullets()
        {
            foreach (var bullet in activeBullets.ToList())
            {
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        private void OnBulletHit(Bullet bullet)
        {
            RemoveBullet(bullet);
        }
    }
}