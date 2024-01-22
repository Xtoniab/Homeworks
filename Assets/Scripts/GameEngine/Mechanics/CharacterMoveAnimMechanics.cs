using Atomic.Elements;
using GameEngine.Common;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class CharacterMoveAnimMechanics
    {
        private static readonly int MainState = Animator.StringToHash("MainState");

        private readonly Animator animator;
        private readonly IAtomicValue<bool> isMoving;

        public CharacterMoveAnimMechanics(Animator animator, IAtomicValue<bool> isMoving)
        {
            this.animator = animator;
            this.isMoving = isMoving;
        }
        
        public void Update()
        {
            if (isMoving.Value)
            {
                animator.SetInteger(MainState, (int) CharacterAnimationState.MOVE);
            }
            else
            {
                animator.SetInteger(MainState, (int) CharacterAnimationState.IDLE);
            }
        }
    }
}