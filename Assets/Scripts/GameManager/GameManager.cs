using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Character playerCharacter;
        [SerializeField] private EnemySpawner enemySpawner;
        
        private void Awake()
        {
            playerCharacter.Construct(bulletSystem);
        }

        private void Start()
        {
            enemySpawner.StartSpawnLoop();
        }

        private void OnEnable()
        {
            playerCharacter.OnDeath += FinishGame;
        }
        
        private void OnDisable()
        {
            playerCharacter.OnDeath -= FinishGame;
        }

        public void FinishGame()
        {
            playerCharacter.OnDeath -= FinishGame;
            
            Debug.Log("Game over!");
            enemySpawner.TryStopSpawnLoop();
            Time.timeScale = 0;
        }
    }
}