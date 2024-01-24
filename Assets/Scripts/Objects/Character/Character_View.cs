using System;
using Animation;
using GameEngine.Mechanics;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public class Character_View
    {
        [SerializeField] private Transform transform;
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationEventReceiver animationEventReceiver;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private AudioClip shotAudioClip;
        [SerializeField] private AudioClip deathAudioClip;


        private LookRotationMechanics lookRotationMechanics;
        private MoveAnimMechanics moveAnimMechanics;
        private ShootAnimMechanics shootAnimMechanics;
        private FireMechanics fireMechanics;


        public void Compose(Character_Core core, AudioSource audioSource)
        {
            lookRotationMechanics = new LookRotationMechanics(transform, core.moveComponent.Direction);
            moveAnimMechanics = new MoveAnimMechanics(animator, core.moveComponent.IsMoving);
            shootAnimMechanics = new ShootAnimMechanics(animator, core.attackComponent.AttackEvent);
            fireMechanics = new FireMechanics(core.weapon.FireAction, animationEventReceiver);

            core.healthComponent.DeathEvent.Subscribe(() => audioSource.PlayOneShot(deathAudioClip));
            core.weapon.FireEvent.Subscribe(() => audioSource.PlayOneShot(shotAudioClip));
            core.weapon.FireEvent.Subscribe(muzzleFlash.Play);
        }

        public void OnEnable()
        {
            fireMechanics.OnEnable();
            shootAnimMechanics.OnEnable();
        }

        public void OnDisable()
        {
            fireMechanics.OnDisable();
            shootAnimMechanics.OnDisable();
        }

        public void Update()
        {
            lookRotationMechanics.Update();
            moveAnimMechanics.Update();
        }
    }
}