using Atomic.Objects;
using Systems;
using UnityEngine;

namespace Objects
{
    public class Character : AtomicObject
    {
        [Section, SerializeField] private Character_Core core = new();
        [Section, SerializeField] private Character_View view = new();
        
        public void Compose(BulletSystem bulletSystem, AudioSource audioSource)
        {
            base.Compose();
            core.Compose(bulletSystem);
            view.Compose(core, audioSource);
       }

        private void OnEnable()
        {
            core.OnEnable();
            view.OnEnable();
        }

        private void OnDisable()
        {
            core.OnDisable();
            view.OnDisable();
        }

        private void FixedUpdate()
        {
            core.FixedUpdate();
        }

        private void Update()
        {
            view.Update();
        }
    }
}