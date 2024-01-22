using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;

namespace GameEngine.Actions
{
    [Serializable]
    public class DealDamageAction: IAtomicAction<AtomicObject>
    {
        private IAtomicValue<int> damage;
        
        public void Compose(IAtomicValue<int> damage)
        {
            this.damage = damage;
        }
        
        [Button]
        public void Invoke(AtomicObject obj)
        {
            if (obj.TryGet(ObjectApi.TakeDamageAction, out IAtomicAction<int> takeDamageAction))
            {
                takeDamageAction.Invoke(damage.Value);
            }
        }
    }
}