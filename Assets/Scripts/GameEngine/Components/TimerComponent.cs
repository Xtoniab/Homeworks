using System;
using Atomic.Elements;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class TimerComponent: IDisposable
    {
        public IAtomicObservable TimeOutEvent => timeOutEvent;
        public IAtomicVariable<float> TimeLeft => timeLeft;
        
        [SerializeField] private AtomicVariable<float> timeLeft = new(1f);
        [SerializeField] private AtomicEvent timeOutEvent = new();

        private TimerMechanics timerMechanics;
        
        public void Compose()
        {
            timerMechanics = new TimerMechanics(timeLeft, timeOutEvent);
        }

        public void FixedUpdate()
        {
            timerMechanics.FixedUpdate();
        }

        public void Dispose()
        {
            timeLeft?.Dispose();
            timeOutEvent?.Dispose();
        }
    }
}