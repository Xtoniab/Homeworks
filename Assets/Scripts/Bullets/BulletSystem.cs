using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private BulletFactory bulletFactory;

        private readonly HashSet<Bullet> activeBullets = new();
        
        public void SpawnBullet(BulletSpawnOptions options)
        {
            var bullet = this.bulletFactory.CreateBullet(options);
            
            if (this.activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            if (this.activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                this.bulletFactory.Pool(bullet);
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

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            var other = collision.gameObject;
            
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.TeamTag == team.TeamTag)
            {
                return;
            }

            if (other.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(bullet.Damage);
            }
            
            this.RemoveBullet(bullet);
        }
    }
}