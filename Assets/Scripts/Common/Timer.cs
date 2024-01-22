using System;
using Atomic.Elements;
using UnityEngine;

namespace Common
{
    [Serializable]
    public class Timer: IDisposable
    {
        public event Action OnTimeOut;
        public float TimeLeft { get; set; }

        public void FixedUpdate()
        {
            TimeLeft -= Time.fixedDeltaTime;
            
            if (TimeLeft <= 0)
            {
                TimeLeft = 0f;
                OnTimeOut?.Invoke();
            }
        }
        
        public void Dispose()
        {
            AtomicUtils.Dispose(ref OnTimeOut);
        }
    }
}