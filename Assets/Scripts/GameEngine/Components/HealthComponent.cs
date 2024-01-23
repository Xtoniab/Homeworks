using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class HealthComponent
    {
        public IAtomicValue<bool> IsAlive => isAlive;
        public IAtomicObservable DeathEvent => deathEvent;

        [Get(ObjectApi.IsAlive), SerializeField] 
        private AtomicVariable<bool> isAlive = new(true);
        
        [Get(ObjectApi.TakeDamageAction), SerializeField]
        private TakeDamageAction takeDamageAction = new();
        
        [SerializeField]
        private AtomicVariable<int> hitPoints = new(5);
        
        [Get(ObjectApi.DeathEvent), SerializeField]
        private AtomicEvent deathEvent = new();
        
        private DeathMechanics deathMechanics;
        
        public void Compose()
        {
            takeDamageAction.Compose(hitPoints);
            
            deathMechanics = new DeathMechanics(hitPoints, isAlive, deathEvent);
        }
        
        public void OnEnable()
        {
            deathMechanics.OnEnable();
        }
        
        public void OnDisable()
        {
            deathMechanics.OnDisable();
        }
    }
}