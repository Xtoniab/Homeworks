using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private EnemyPool enemyPool;

        private Coroutine enemySpawnLoop;

        public void StartSpawnLoop()
        {
            TryStopSpawnLoop();
            enemySpawnLoop = StartCoroutine(EnemySpawnLoop());
        }
        
        public void TryStopSpawnLoop()
        {
            if (enemySpawnLoop != null)
            {
                StopCoroutine(enemySpawnLoop);
            }
        }
        
        private IEnumerator EnemySpawnLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnDelay);
                var enemy = this.enemyPool.Get();
                if (enemy != null)
                {
                    enemy.OnDeath += () => enemyPool.Pool(enemy);
                }
            }
        }
    }
}