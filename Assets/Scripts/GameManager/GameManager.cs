using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public event Action OnGameStart;
        public event Action OnGameFinish;
        
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Character playerCharacter;
        
        private void Awake()
        {
            playerCharacter.Construct(bulletSystem);
        }

        private void Start()
        {
            OnGameStart?.Invoke();
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
            Debug.Log("Game over!");
            Time.timeScale = 0;
            
            OnGameFinish?.Invoke();
        }
    }
}