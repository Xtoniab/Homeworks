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
        [Get(ObjectApi.IsAlive), SerializeField] 
        private AtomicVariable<bool> isAlive = new(true);
        
        [Get(ObjectApi.TakeDamageAction), SerializeField]
        private TakeDamageAction takeDamageAction = new();
        
        [SerializeField]
        private AtomicVariable<int> hitPoints = new(5);
        
        private DeathMechanics deathMechanics;
        
        public void Compose()
        {
            takeDamageAction.Compose(hitPoints);
            
            deathMechanics = new DeathMechanics(hitPoints, isAlive);
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