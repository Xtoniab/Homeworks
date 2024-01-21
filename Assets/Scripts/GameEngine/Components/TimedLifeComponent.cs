using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class TimedLifeComponent: IDisposable
    {
        public IAtomicValue<bool> IsAlive => isAlive;

        [SerializeField] 
        private AtomicValue<float> lifeTimeSeconds = new(5f);
        
        [Get(ObjectApi.IsAlive), SerializeField] 
        private AtomicVariable<bool> isAlive = new(true);
        
        [SerializeField]
        private TimerComponent timerComponent = new();

        public void Compose()
        {
            timerComponent.Compose();
            timerComponent.TimeLeft.Value = lifeTimeSeconds.Value;
            timerComponent.TimeOutEvent.Subscribe(() => isAlive.Value = false);
        }

        public void Reset()
        {
            isAlive.Value = true;
            timerComponent.TimeLeft.Value = lifeTimeSeconds.Value;
        }
        
        public void FixedUpdate()
        {
            timerComponent.FixedUpdate();
        }

        public void Dispose()
        {
            isAlive?.Dispose();
            timerComponent?.Dispose();
        }
    }
}