using System;
using Atomic.Elements;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class MoveComponent
    {
        public IAtomicExpression<bool> MoveEnabled => moveEnabled;
        
        [SerializeField] private Transform transform;
        [SerializeField] private AtomicValue<float> speed = new(1f);
        [SerializeField] private AtomicVariable<Vector3> direction = new(Vector3.forward);
        
        private MoveMechanics moveMechanics;
        private AndCondition moveEnabled = new();
        
        public void Compose()
        {
            moveMechanics = new MoveMechanics(transform, speed, direction, moveEnabled);
        }
        
        public void FixedUpdate()
        {
            moveMechanics.FixedUpdate();
        }
    }
}