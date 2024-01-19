using Atomic.Elements;
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
            character.Get<IAtomicObservable<bool>>(ObjectApi.IsAlive).Subscribe(OnDeath);
        }
        
        private void OnDisable()
        {
            character.Get<IAtomicObservable<bool>>(ObjectApi.IsAlive).Unsubscribe(OnDeath);
        }

        private void OnDeath(bool isAlive)
        {
            if (!isAlive)
            {
                Destroy(character.gameObject);
            }
        }
    }
}