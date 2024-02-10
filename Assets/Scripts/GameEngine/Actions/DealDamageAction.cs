using System;
using Atomic.Elements;
using Atomic.Extensions;
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
            if (obj != null && obj.Is(HealthAPI.Damageable))
            {
                obj.InvokeAction(HealthAPI.TakeDamageAction, damage.Value);
            }
        }
    }
}