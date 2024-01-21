using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Game.Engine;

namespace GameEngine.Mechanics
{
    [Serializable]
    public class AndCondition: AtomicExpression<bool>
    {
        protected override bool Invoke(IReadOnlyList<IAtomicValue<bool>> members)
        {
            return members.All(member => member.Value);
        }
    }
}