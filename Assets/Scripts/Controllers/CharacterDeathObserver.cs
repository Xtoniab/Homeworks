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
            character.GetObservable<bool>(ObjectApi.IsAlive).Subscribe(OnAliveChanged);
        }
        
        private void OnDisable()
        {
            character.GetObservable<bool>(ObjectApi.IsAlive).Unsubscribe(OnAliveChanged);
        }

        private void OnAliveChanged(bool isAlive)
        {
            if (!isAlive)
            {
                Destroy(character.gameObject);
            }
        }
    }
}