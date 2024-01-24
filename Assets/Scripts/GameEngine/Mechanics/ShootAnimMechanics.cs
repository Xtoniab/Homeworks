using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class ShootAnimMechanics
    {
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        
        private readonly Animator animator;
        private readonly IAtomicObservable shootEvent;

        public ShootAnimMechanics(Animator animator, IAtomicObservable shootEvent)
        {
            this.animator = animator;
            this.shootEvent = shootEvent;
        }
        
        public void OnEnable()
        {
            shootEvent.Subscribe(PlayShootAnim);
        }
        
        public void OnDisable()
        {
            shootEvent.Unsubscribe(PlayShootAnim);
        }

        private void PlayShootAnim()
        {
            animator.SetTrigger(Shoot);
        }
    }
}