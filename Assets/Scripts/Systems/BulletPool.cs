using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Systems
{
    internal class BulletPool: MonoBehaviour
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private int initialSize = 10;
        [SerializeField] private Transform container;
        
        private readonly Queue<Bullet> pooledBullets = new();
        
        private void Awake()
        {
            WarmupPool();
        }
        
        private void WarmupPool()
        {
            for (var i = 0; i < initialSize; i++)
            {
                InstantiateAndPoolNewBullet();
            }
        }

        private void InstantiateAndPoolNewBullet()
        {
            var newBullet = Instantiate(prefab, container);
            newBullet.Compose();
            pooledBullets.Enqueue(newBullet);
        }

        public Bullet Get()
        {
            if (pooledBullets.Count == 0)
            {
                InstantiateAndPoolNewBullet();
            }

            var bullet = pooledBullets.Dequeue();
            return bullet;
        }

        public void Pool(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            pooledBullets.Enqueue(bullet);
        }
    }
}