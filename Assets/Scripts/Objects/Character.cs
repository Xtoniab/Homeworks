using Atomic.Objects;
using GameEngine.Components;
using Systems;
using UnityEngine;

namespace Objects
{
    public class Character : AtomicObject
    {
        [Section, SerializeField] private HealthComponent healthComponent = new();
        [Section, SerializeField] private WeaponComponent weaponComponent = new();

        public void Compose(BulletSystem bulletSystem)
        {
            base.Compose();

            healthComponent.Compose();
            weaponComponent.Compose(bulletSystem);
        }

        private void OnEnable()
        {
            healthComponent.OnEnable();
        }

        private void OnDisable()
        {
            healthComponent.OnDisable();
        }
    }
}