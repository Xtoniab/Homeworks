using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class FireMechanics
    {
        private readonly IAtomicAction fireAction;
        private readonly IAtomicEvent fireEvent;
        
        public FireMechanics(IAtomicAction fireAction, IAtomicEvent fireEvent)
        {
            this.fireAction = fireAction;
            this.fireEvent = fireEvent;
        }
        
        public void OnEnable()
        {
            fireEvent.Subscribe(fireAction.Invoke);
        }
        
        public void OnDisable()
        {
            fireEvent.Unsubscribe(fireAction.Invoke);
        }
    }
}