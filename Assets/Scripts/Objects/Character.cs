using Atomic.Elements;
using Atomic.Objects;
using GameEngine;
using GameEngine.Actions;
using GameEngine.Mechanics;
using Systems;
using UnityEngine;

namespace Objects
{
    public class Character: AtomicObject
    {
        [Header("Health")]
        [Get(ObjectApi.IsAlive), SerializeField] private AtomicVariable<bool> isAlive = new(true);
        [Get(ObjectApi.TakeDamageEvent), SerializeField] private AtomicEvent<float> takeDamageEvent = new();
        [SerializeField] private AtomicVariable<float> hitPoints = new(5f);

        private TakeDamageMechanics takeDamageMechanics;
        private DeathMechanics deathMechanics;
        
        
        [Header("Fire")]
        [Get(ObjectApi.FireEvent), SerializeField] private AtomicEvent fireEvent = new();
        [SerializeField] private FireAction fireAction;
        [SerializeField] private Transform firePoint;
        
        private FireMechanics fireMechanics;

        public void Construct(BulletSystem bulletSystem)
        {
            base.Compose();

            takeDamageMechanics = new TakeDamageMechanics(takeDamageEvent, hitPoints);
            deathMechanics = new DeathMechanics(hitPoints, isAlive);
            fireMechanics = new FireMechanics(fireAction, fireEvent);
            fireAction = new FireAction(bulletSystem, firePoint);
        }

        private void OnEnable()
        {
            takeDamageMechanics.OnEnable();
            deathMechanics.OnEnable();
            fireMechanics.OnEnable();
        }

        private void OnDisable()
        {
            takeDamageMechanics.OnDisable();
            deathMechanics.OnDisable();
            fireMechanics.OnDisable();
        }
    }
}