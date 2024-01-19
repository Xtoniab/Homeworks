using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class DeathMechanics
    {
        private readonly IAtomicObservable<float> hitPoints;
        private readonly IAtomicVariable<bool> isAlive;
        
        public DeathMechanics(IAtomicObservable<float> hitPoints, IAtomicVariable<bool> isAlive)
        {
            this.hitPoints = hitPoints;
            this.isAlive = isAlive;
        }

        public void OnEnable()
        {
            hitPoints.Subscribe(OnHitPointsChanged);
        }
        
        public void OnDisable()
        {
            hitPoints.Unsubscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(float hitPoints)
        {
            if (hitPoints <= 0)
            {
                isAlive.Value = false;
            }
        }
    }
}