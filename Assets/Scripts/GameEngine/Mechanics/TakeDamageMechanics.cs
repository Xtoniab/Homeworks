using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class TakeDamageMechanics
    {
        private readonly IAtomicEvent<float> takeDamageEvent;
        private readonly IAtomicVariable<float> hitPoints;

        public TakeDamageMechanics(IAtomicEvent<float> takeDamageEvent, IAtomicVariable<float> hitPoints)
        {
            this.takeDamageEvent = takeDamageEvent;
            this.hitPoints = hitPoints;
        }

        public void OnEnable()
        {
            takeDamageEvent.Subscribe(OnTakeDamage);
        }
        
        public void OnDisable()
        {
            takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(float damage)
        {
            damage = Mathf.Min(hitPoints.Value, damage);
            hitPoints.Value -= damage;
        }
    }
}