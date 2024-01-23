using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine;
using UnityEngine;

namespace Controllers
{
    public class CharacterDeathObserver: MonoBehaviour
    {
        [SerializeField] private AtomicObject character;
        
        private void OnEnable()
        {
            character.GetObservable(ObjectApi.DeathEvent).Subscribe(OnDeath);
        }
        
        private void OnDisable()
        {
            character.GetObservable(ObjectApi.DeathEvent).Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            Destroy(character.gameObject);
        }
    }
}