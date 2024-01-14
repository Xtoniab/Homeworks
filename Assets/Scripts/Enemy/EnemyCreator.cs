using Pool;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCreator : MonoBehaviour
    {
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private GameObjectPool enemyPool;
        [SerializeField] private GameObject character;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Transform worldTransform;
        
        public bool TryCreate(out Enemy enemy)
        {
            if (!this.enemyPositions.HasAvailableAttackPositions)
            {
                enemy = null;
                return false;
            }
            
            var attackPositionHandle = this.enemyPositions.AcquireRandomAttackPosition();
            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            
            var enemyPoolObject = this.enemyPool.Get();
            var enemyTransform = enemyPoolObject.transform;
            var enemyComponent = enemyTransform.GetComponent<Enemy>();
            var shipComponent = enemyTransform.GetComponent<ShipComponent>();

            enemyTransform.SetParent(this.worldTransform);
            enemyTransform.position = spawnPosition.position;
            enemyComponent.Construct(attackPositionHandle, this.character);
            shipComponent.Construct(bulletSystem);
            
            enemy = enemyComponent;
            
            return true;
        }
    }
}