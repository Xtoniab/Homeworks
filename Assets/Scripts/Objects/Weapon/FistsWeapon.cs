using System;
using Atomic.Elements;
using Common;
using GameEngine.Actions;
using GameEngine.Components;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public class FistsWeapon
    {
        [SerializeField]
        private AtomicValue<int> damage = new(1);
        
        [SerializeField]
        private AtomicValue<float> radius = new(1);
        
        private DamageFirstTargetInFrontAreaAction areaDamageAction = new();
        private DealDamageAction dealDamageAction = new();
        
        public void Compose(Transform transform)
        {
            dealDamageAction.Compose(damage);
            areaDamageAction.Compose(transform, radius, dealDamageAction, LayerMasks.ObjectsLayer);
        }        
    }
}