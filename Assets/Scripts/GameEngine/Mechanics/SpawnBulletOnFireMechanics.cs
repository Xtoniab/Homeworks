using Animation;
using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class SpawnBulletOnFireMechanics
    {
        private readonly IAtomicAction spawnBulletAction;
        private readonly AnimationEventReceiver animationEventReceiver;
        
        public SpawnBulletOnFireMechanics(
            IAtomicAction spawnBulletAction,
            AnimationEventReceiver animationEventReceiver)
        {
            this.spawnBulletAction = spawnBulletAction;
            this.animationEventReceiver = animationEventReceiver;
        }
        
        public void OnEnable()
        {
            animationEventReceiver.OnEvent += HandleAnimationEvent;
        }
        
        public void OnDisable()
        {
            animationEventReceiver.OnEvent -= HandleAnimationEvent;
        }
        
        private void HandleAnimationEvent(AnimationEventType eventType)
        {
            if (eventType == AnimationEventType.Fire)
            {
                spawnBulletAction.Invoke();
            }
        }
    }
}