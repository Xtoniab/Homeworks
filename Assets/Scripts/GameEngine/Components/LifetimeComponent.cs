using System;
using Atomic.Elements;
using Atomic.Objects;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    [Serializable]
    public class LifetimeComponent : IDisposable
    {
        public IAtomicValue<bool> IsAlive => isAlive;

        [SerializeField] private AtomicValue<float> lifeTimeSeconds = new(5f);

        [Get(HealthAPI.IsAlive), SerializeField]
        private AtomicVariable<bool> isAlive = new(true);

        [SerializeField] private Timer timer = new();

        public void Compose()
        {
            timer.TimeLeft = lifeTimeSeconds.Value;
            timer.OnTimeOut += () => isAlive.Value = false;
        }

        public void Reset()
        {
            isAlive.Value = true;
            timer.TimeLeft = lifeTimeSeconds.Value;
        }

        public void FixedUpdate()
        {
            timer.FixedUpdate();
        }

        public void Dispose()
        {
            isAlive?.Dispose();
            timer?.Dispose();
        }
    }
}