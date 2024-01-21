using Objects;
using UnityEngine;

namespace Systems
{
    internal class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private Transform worldTransform;
        public Bullet Spawn(Vector3 position, Quaternion rotation)
        {
            var bullet = bulletPool.Get();
            var bulletTransform = bullet.transform;
            bulletTransform.position = position;
            bulletTransform.rotation = rotation;
            bullet.Reset();
            
            bulletTransform.SetParent(worldTransform);

            return bullet;
        }
    }
}