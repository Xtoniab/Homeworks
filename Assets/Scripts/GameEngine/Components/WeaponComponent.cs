using System;
using Animation;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Mechanics;
using Systems;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class WeaponComponent
    {
        public IAtomicExpression<bool> CanFire => canFire;
        public IAtomicObservable FireEvent => fireEvent;
        public IAtomicObservable SpawnBulletEvent => spawnBulletEvent;

        [SerializeField] 
        private AnimationEventReceiver animationEventReceiver;

        [SerializeField] 
        private Transform firePoint;

        [Get(ObjectApi.FireAction), SerializeField]
        private FireAction fireAction = new();
        
        [SerializeField] 
        private AtomicEvent fireEvent = new();

        [SerializeField] 
        private SpawnBulletAction spawnBulletAction = new();
        
        [SerializeField] 
        private AtomicEvent spawnBulletEvent = new();

        [SerializeField]
        private AndCondition canFire = new();

        private SpawnBulletOnFireMechanics spawnBulletOnFireMechanics;

        public void Compose(BulletSystem bulletSystem)
        {
            fireAction.Compose(canFire, fireEvent);
            spawnBulletAction.Compose(bulletSystem, firePoint, spawnBulletEvent);

            spawnBulletOnFireMechanics = new SpawnBulletOnFireMechanics(spawnBulletAction, animationEventReceiver);
        }

        public void OnEnable()
        {
            spawnBulletOnFireMechanics.OnEnable();
        }

        public void OnDisable()
        {
            spawnBulletOnFireMechanics.OnDisable();
        }
    }
}