using Atomic.Elements;
using Atomic.Objects;
using GameEngine;
using InputManagement;
using UnityEngine;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private AtomicObject character;

        private void OnEnable()
        {
            inputManager.OnFire += Fire;
        }
        
        private void OnDisable()
        {
            inputManager.OnFire -= Fire;
        }

        private void Fire()
        {
            character.Get<IAtomicEvent>(ObjectApi.FireEvent).Invoke();
        }
    }
}