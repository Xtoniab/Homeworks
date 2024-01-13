using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;

        private readonly Queue<Bullet> bulletPool = new();

        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.prefab, this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }

        public Bullet CreateBullet(BulletSpawnOptions bulletOptions)
        {
            if (this.bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }

            bullet.SetPosition(bulletOptions.position);
            bullet.SetColor(bulletOptions.color);
            bullet.SetPhysicsLayer(bulletOptions.physicsLayer);
            bullet.SetDamage(bulletOptions.damage);
            bullet.SetTeamTag(bulletOptions.teamTag);
            bullet.SetVelocity(bulletOptions.velocity);
            
            return bullet;
        }

        public void Pool(Bullet bullet)
        {
            bullet.transform.SetParent(this.container);
            this.bulletPool.Enqueue(bullet);
        }
    }
}