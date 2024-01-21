using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public sealed class TimerMechanics
    {
        private readonly IAtomicVariable<float> timeLeft;
        private readonly IAtomicEvent onTimeOut;

        public TimerMechanics(IAtomicVariable<float> timeLeft, IAtomicEvent onTimeOut)
        {
            this.timeLeft = timeLeft;
            this.onTimeOut = onTimeOut;
        }

        public void FixedUpdate()
        {
            if (timeLeft.Value <= 0f)
            {
                return;
            }

            timeLeft.Value -= Time.fixedDeltaTime;

            if (timeLeft.Value <= 0f)
            {
                timeLeft.Value = 0f;
                onTimeOut.Invoke();
            }
        }
    }
}