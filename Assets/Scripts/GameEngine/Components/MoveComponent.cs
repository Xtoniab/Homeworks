using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class MoveComponent
    {
        public IAtomicValue<bool> IsMoving => isMoving;
        public IAtomicExpression<bool> MoveEnabled => moveEnabled;
        public IAtomicValue<Vector3> Direction => direction;
        
        [SerializeField]
        private Transform transform;
        
        [SerializeField]
        private AtomicValue<float> speed = new(1f);
        
        [Get(ObjectApi.MoveDirection), SerializeField]
        private AtomicVariable<Vector3> direction = new(Vector3.forward);
        
        [SerializeField]
        private AtomicFunction<bool> isMoving = new();
        
        private MoveMechanics moveMechanics;
        private AndCondition moveEnabled = new();
        
        public void Compose()
        {
            moveMechanics = new MoveMechanics(transform, speed, direction, moveEnabled);
            isMoving.Compose(() => direction.Value != Vector3.zero && moveEnabled.Invoke());
        }
        
        public void FixedUpdate()
        {
            moveMechanics.FixedUpdate();
        }
    }
}