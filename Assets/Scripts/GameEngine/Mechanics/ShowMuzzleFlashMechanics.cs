using Animation;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class ShowMuzzleFlashMechanics
    {
        private readonly ParticleSystem muzzleFlash;
        private readonly IAtomicObservable spawnBulletEvent;
        
        public ShowMuzzleFlashMechanics(ParticleSystem muzzleFlash, IAtomicObservable spawnBulletEvent)
        {
            this.muzzleFlash = muzzleFlash;
            this.spawnBulletEvent = spawnBulletEvent;
        }
        
        public void OnEnable()
        {
            spawnBulletEvent.Subscribe(PlayFireAnim);
        }
        
        public void OnDisable()
        {
            spawnBulletEvent.Unsubscribe(PlayFireAnim);
        }
        
        private void PlayFireAnim()
        {
            muzzleFlash.Play();
        }
    }
}