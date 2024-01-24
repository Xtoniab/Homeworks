using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class AttackComponent
    {
        public IAtomicExpression<bool> CanAttack => canAttack;
        public IAtomicObservable AttackEvent => attackEvent;
        
        [Get(ObjectApi.AttackAction), SerializeField]
        private AttackAction attackAction = new();
        
        [SerializeField] 
        private AtomicEvent attackEvent = new();
        
        [SerializeField]
        private AndCondition canAttack = new();
        
        public void Compose()
        {
            attackAction.Compose(canAttack, attackEvent);
        }
    }
}