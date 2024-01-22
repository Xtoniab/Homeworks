using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class DeathMechanics
    {
        private readonly IAtomicObservable<int> hitPoints;
        private readonly IAtomicVariable<bool> isAlive;
        private readonly IAtomicEvent deathEvent;
        
        public DeathMechanics(IAtomicObservable<int> hitPoints, IAtomicVariable<bool> isAlive, IAtomicEvent deathEvent)
        {
            this.hitPoints = hitPoints;
            this.isAlive = isAlive;
            this.deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            hitPoints.Subscribe(OnHitPointsChanged);
        }
        
        public void OnDisable()
        {
            hitPoints.Unsubscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            isAlive.Value = hitPoints > 0;

            if (!isAlive.Value)
            {
                deathEvent.Invoke();
            }
        }
    }
}