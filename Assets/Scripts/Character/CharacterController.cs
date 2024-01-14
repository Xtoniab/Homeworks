using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private ShipComponent shipComponent;
        [SerializeField] private InputManager inputManager;
        
        private void OnEnable()
        {
            this.inputManager.OnFire += shipComponent.FireForward;
        }

        private void FixedUpdate()
        {
            this.shipComponent.Move(this.inputManager.MoveDirection);
        }

        private void OnDisable()
        {
            this.inputManager.OnFire -= shipComponent.FireForward;
        }
    }
}