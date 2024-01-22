using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class CharacterFireAnimMechanics
    {
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        
        private readonly Animator animator;
        private readonly IAtomicObservable fireEvent;

        public CharacterFireAnimMechanics(Animator animator, IAtomicObservable fireEvent)
        {
            this.animator = animator;
            this.fireEvent = fireEvent;
        }
        
        public void OnEnable()
        {
            fireEvent.Subscribe(PlayFireAnim);
        }
        
        public void OnDisable()
        {
            fireEvent.Unsubscribe(PlayFireAnim);
        }

        private void PlayFireAnim()
        {
            animator.SetTrigger(Shoot);
        }
    }
}