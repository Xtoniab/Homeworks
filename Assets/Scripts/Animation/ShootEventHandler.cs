using System;
using Atomic.Elements;
using UnityEngine;

namespace Animation
{
   public class AnimationEventReceiver : MonoBehaviour
   {
      public event Action<AnimationEventType> OnEvent;
   
      public void ReceiveEvent(AnimationEventType type)
      {
         OnEvent?.Invoke(type);
      }

      private void OnDestroy()
      {
         AtomicUtils.Dispose(ref OnEvent);
      }
   }
}