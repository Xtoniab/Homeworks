using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace GameEngine.Actions
{
    [Serializable]
    public class AttackAction: IAtomicAction
    {
        private IAtomicValue<bool> canAttack;
        private IAtomicEvent attackEvent;

        public void Compose(IAtomicValue<bool> canAttack, IAtomicEvent attackEvent)
        {
            this.canAttack = canAttack;
            this.attackEvent = attackEvent;
        }
        
        [Button]
        public void Invoke()
        {
            if (canAttack.Value)
            {
                attackEvent.Invoke();
            }
        }
    }
}