using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private GameObject character;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Transform worldTransform;

        [Header("Pool")]
        [SerializeField] private int initialPoolSize = 7;
        [SerializeField] private Transform container;
        [SerializeField] private Character prefab;

        private readonly Queue<Character> pooledEnemies = new();
        
        private void Awake()
        {
            WarmupPool();
        }

        private void WarmupPool()
        {
            for (var i = 0; i < initialPoolSize; i++)
            {
                InstantiateAndPoolNewEnemy();
            }
        }

        private void InstantiateAndPoolNewEnemy()
        {
            var enemy = Instantiate(this.prefab, this.container);
            this.pooledEnemies.Enqueue(enemy);
        }

        public Character Get()
        {
            if (!this.enemyPositions.HasAvailableAttackPositions)
            {
                return null;
            }
            
            if (this.pooledEnemies.Count == 0)
            {
                InstantiateAndPoolNewEnemy();
            }
            
            var enemy = this.pooledEnemies.Dequeue();

            enemy.transform.SetParent(this.worldTransform);

            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = this.enemyPositions.AcquireRandomAttackPosition();
            
            enemy.GetComponent<Character>().Construct(bulletSystem);
            enemy.GetComponent<EnemyCharacterController>().Construct(attackPosition, this.character);
            return enemy;
        }

        public void Pool(Character enemy)
        {
            enemy.Reset();

            var attackPosition = enemy.GetComponent<EnemyCharacterController>().AttackPosition;
            this.enemyPositions.ReleaseAttackPosition(attackPosition);
            
            enemy.transform.SetParent(this.container);
            this.pooledEnemies.Enqueue(enemy);
        }
    }
}