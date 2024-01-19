using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class MoveMechanics
    {
        private readonly Transform transform;
        private readonly IAtomicValue<float> speed;
        private readonly IAtomicValue<Vector3> direction;
        private readonly IAtomicValue<bool> canMove;

        public MoveMechanics(
            Transform transform,
            IAtomicValue<float> speed,
            IAtomicValue<Vector3> direction,
            IAtomicValue<bool> canMove)
        {
            this.transform = transform;
            this.speed = speed;
            this.direction = direction;
            this.canMove = canMove;
        }

        public void FixedUpdate()
        {
            if (canMove.Value)
            {
                var movement = direction.Value * speed.Value * Time.fixedDeltaTime;
                transform.Translate(movement);
            }
        }
    }
}