using System;
using UnityEngine;

namespace InputManagement
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnFire;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnFire?.Invoke();
            }
        }
    }
}