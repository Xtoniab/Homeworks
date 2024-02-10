using System;
using UnityEngine;

namespace InputManagement
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnAttack;
        public Vector2 MoveDirection { get; private set; }

        public bool AttackPressed { get; private set; }

        private void Update()
        {
            MoveDirection = Vector2.zero;

            if (Input.GetMouseButtonDown(0))
            {
                OnAttack?.Invoke();
            }
            
            AttackPressed = Input.GetMouseButton(0);

            if (Input.GetKey(KeyCode.A)) MoveDirection += Vector2.left;
            if (Input.GetKey(KeyCode.D)) MoveDirection += Vector2.right;
            if (Input.GetKey(KeyCode.W)) MoveDirection += Vector2.up;
            if (Input.GetKey(KeyCode.S)) MoveDirection += Vector2.down;
        }
    }
}