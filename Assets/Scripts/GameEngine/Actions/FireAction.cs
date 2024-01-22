using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using Systems;
using UnityEngine;

namespace GameEngine.Actions
{
    [Serializable]
    public class FireAction: IAtomicAction
    {
        private IAtomicValue<bool> canFire;
        private IAtomicEvent fireEvent;

        public void Compose(
            IAtomicValue<bool> canFire,
            IAtomicEvent fireEvent)
        {
            this.canFire = canFire;
            this.fireEvent = fireEvent;
        }
        
        [Button]
        public void Invoke()
        {
            if (canFire.Value == false)
            {
                return;
            }
            
            fireEvent.Invoke();
        }
    }
}