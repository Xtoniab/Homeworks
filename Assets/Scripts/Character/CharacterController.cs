using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private InputManager inputManager;
        
        private void OnEnable()
        {
            this.inputManager.OnFire += character.FireForward;
        }

        private void FixedUpdate()
        {
            this.character.Move(this.inputManager.MoveDirection);
        }

        private void OnDisable()
        {
            this.inputManager.OnFire -= character.FireForward;
        }
    }
}