using Pool;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletCreator: MonoBehaviour
    {
        [SerializeField] private GameObjectPool bulletPool;
        [SerializeField] private Transform worldTransform;

        public Bullet Create(BulletSpawnOptions options)
        {
            var bulletObject = this.bulletPool.Get();
            var bullet = bulletObject.GetComponent<Bullet>();
            bullet.transform.SetParent(this.worldTransform);
            bullet.SetPosition(options.position);
            bullet.SetColor(options.color);
            bullet.SetPhysicsLayer(options.physicsLayer);
            bullet.SetDamage(options.damage);
            bullet.SetTeamTag(options.teamTag);
            bullet.SetVelocity(options.velocity);

            return bullet;
        }
    }
}