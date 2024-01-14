using UnityEngine;

namespace ShootEmUp
{
    public class CharacterDeathObserver: MonoBehaviour
    {
        [SerializeField] private ShipComponent character;
        [SerializeField] private GameManager gameManager;
        
        private void OnEnable()
        {
            this.character.OnDeath += gameManager.FinishGame;
        }
        
        private void OnDisable()
        {
            this.character.OnDeath -= gameManager.FinishGame;
        }
    }
}