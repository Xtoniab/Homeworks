using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class PlaySoundByEventMechanics
    {
        private readonly AudioSource audioSource;
        private readonly AudioClip sound;
        private readonly IAtomicObservable @event;
        
        public PlaySoundByEventMechanics(AudioSource audioSource, AudioClip sound, IAtomicObservable @event)
        {
            this.audioSource = audioSource;
            this.sound = sound;
            this.@event = @event;
        }
        
        public void OnEnable()
        {
            @event.Subscribe(PlaySound);
        }
        
        public void OnDisable()
        {
            @event.Unsubscribe(PlaySound);
        }
        
        private void PlaySound()
        {
            audioSource.PlayOneShot(sound);
        }
    }
}