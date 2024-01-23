using System;
using GameEngine.Mechanics;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public class Character_View
    {
        [SerializeField] private Transform transform;
        [SerializeField] private Animator animator;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private AudioClip shotAudioClip;
        [SerializeField] private AudioClip deathAudioClip;
        
        private LookRotationMechanics lookRotationMechanics;
        private CharacterMoveAnimMechanics moveAnimMechanics;
        private CharacterFireAnimMechanics fireAnimMechanics;
        private PlayParticlesOnEventMechanics showMuzzleFlashMechanics;
        private PlaySoundByEventMechanics playShotSoundMechanics;
        private PlaySoundByEventMechanics playDeathSoundMechanics;
        
        public void Compose(Character_Core core, AudioSource audioSource)
        {
            lookRotationMechanics = new LookRotationMechanics(transform, core.moveComponent.Direction);
            moveAnimMechanics = new CharacterMoveAnimMechanics(animator, core.moveComponent.IsMoving);
            fireAnimMechanics = new CharacterFireAnimMechanics(animator, core.weaponComponent.FireEvent);
            showMuzzleFlashMechanics = new PlayParticlesOnEventMechanics(muzzleFlash, core.weaponComponent.SpawnBulletEvent);
            playShotSoundMechanics = new PlaySoundByEventMechanics(audioSource, shotAudioClip, core.weaponComponent.SpawnBulletEvent);
            playDeathSoundMechanics = new PlaySoundByEventMechanics(audioSource, deathAudioClip, core.healthComponent.DeathEvent);
        }
        
        public void OnEnable()
        {
            fireAnimMechanics.OnEnable();
            showMuzzleFlashMechanics.OnEnable();
            playShotSoundMechanics.OnEnable();
            playDeathSoundMechanics.OnEnable();
        }
        
        public void OnDisable()
        {
            fireAnimMechanics.OnDisable();
            showMuzzleFlashMechanics.OnDisable();
            playShotSoundMechanics.OnDisable();
            playDeathSoundMechanics.OnDisable();
        }
        
        public void Update()
        {
            lookRotationMechanics.Update();
            moveAnimMechanics.Update();
        }
    }
}