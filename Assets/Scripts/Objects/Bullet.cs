using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine;
using GameEngine.Mechanics;
using UnityEngine;

namespace Objects
{
    public class Bullet: AtomicObject
    {
        [Header("Bullet")]
        [SerializeField] private AtomicValue<float> lifetimeSeconds = new(5f);
        [SerializeField] private AtomicValue<float> damage = new(1f);
        private BulletCollisionMechanics bulletCollisionMechanics;
        
        [Header("Movement")] 
        [SerializeField] private Transform transform;
        [SerializeField] private AtomicValue<float> speed = new(1f);
        [SerializeField] private AtomicVariable<Vector3> direction = new(Vector3.forward);
        private MoveMechanics moveMechanics;
        
        [Header("Health")]
        [Get(ObjectApi.IsAlive), SerializeField] private AtomicVariable<bool> isAlive = new(true);
        [SerializeField] private AtomicVariable<float> hitPoints;
        [SerializeField] private AtomicEvent<float> takeDamageEvent;
        private TakeDamageMechanics takeDamageMechanics;
        private DeathMechanics deathMechanics;
        
        [Header("Time Damage")]
        [SerializeField] private AtomicValue<float> damagePerSecond = new(1f);
        private TimeDamageMechanics timeDamageMechanics;
        
        public Bullet Construct()
        {
            base.Compose();
            
            moveMechanics = new MoveMechanics(transform, speed, direction, canMove: isAlive);
            takeDamageMechanics = new TakeDamageMechanics(takeDamageEvent, hitPoints);
            timeDamageMechanics = new TimeDamageMechanics(takeDamageEvent, damagePerSecond);
            deathMechanics = new DeathMechanics(hitPoints, isAlive);
            bulletCollisionMechanics = new BulletCollisionMechanics(damage, isAlive);
            return this;
        }
        
        public void Reset()
        {
            isAlive.Value = true;
            hitPoints.Value = lifetimeSeconds.Value;
        }

        private void OnEnable()
        {
            takeDamageMechanics.OnEnable();
            deathMechanics.OnEnable();
        }
        
        private void OnDisable()
        {
            takeDamageMechanics.OnDisable();
            deathMechanics.OnDisable();
        }
        
        private void FixedUpdate()
        {
            moveMechanics.FixedUpdate();
            timeDamageMechanics.FixedUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            bulletCollisionMechanics.OnTriggerEnter(other);
        }
    }
}