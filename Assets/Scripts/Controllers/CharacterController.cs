using System;
using Atomic.Elements;
using Atomic.Extensions;
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
            inputManager.OnAttack += Attack;
        }
        
        private void OnDisable()
        {
            inputManager.OnAttack -= Attack;
        }

        private void FixedUpdate()
        {
            var direction = new Vector3(inputManager.MoveDirection.x, 0, inputManager.MoveDirection.y);
            character.GetVariable<Vector3>(ObjectApi.MoveDirection).Value = direction;
        }

        private void Attack()
        {
            character.InvokeAction(ObjectApi.AttackAction);
        }
    }
}