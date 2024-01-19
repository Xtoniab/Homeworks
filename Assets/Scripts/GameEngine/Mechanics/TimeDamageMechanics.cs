using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class TimeDamageMechanics
    {
        private readonly IAtomicEvent<float> takeDamageEvent;
        private readonly IAtomicValue<float> damagePerSecond;

        public TimeDamageMechanics(IAtomicEvent<float> takeDamageEvent, IAtomicValue<float> damagePerSecond)
        {
            this.takeDamageEvent = takeDamageEvent;
            this.damagePerSecond = damagePerSecond;
        }
        
        public void FixedUpdate()
        {
            takeDamageEvent.Invoke(damagePerSecond.Value * Time.fixedDeltaTime);
        }
    }
}