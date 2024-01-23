using Animation;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class PlayParticlesOnEventMechanics
    {
        private readonly ParticleSystem particles;
        private readonly IAtomicObservable @event;
        
        public PlayParticlesOnEventMechanics(ParticleSystem particles, IAtomicObservable @event)
        {
            this.particles = particles;
            this.@event = @event;
        }
        
        public void OnEnable()
        {
            @event.Subscribe(PlayParticles);
        }
        
        public void OnDisable()
        {
            @event.Unsubscribe(PlayParticles);
        }
        
        private void PlayParticles()
        {
            particles.Play();
        }
    }
}