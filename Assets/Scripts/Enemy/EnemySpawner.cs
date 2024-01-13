using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private GameManager gameManager;
        
        private Coroutine enemySpawnLoop;

        private void OnEnable()
        {
            gameManager.OnGameStart += StartSpawnLoop;
            gameManager.OnGameFinish += TryStopSpawnLoop;
        }
        
        private void OnDisable()
        {
            gameManager.OnGameStart -= StartSpawnLoop;
            gameManager.OnGameFinish -= TryStopSpawnLoop;
        }

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