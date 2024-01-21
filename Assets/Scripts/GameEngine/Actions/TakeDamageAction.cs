using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Actions
{
    [Serializable]
    public class TakeDamageAction: IAtomicAction<int>
    {
        private IAtomicVariable<int> health;
        
        public void Compose(IAtomicVariable<int> health)
        {
            this.health = health;
        }

        [Button]
        public void Invoke(int damage)
        {
            damage = Mathf.Min(health.Value, damage);
            health.Value -= damage;
        }
    }
}