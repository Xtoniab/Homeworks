using System;
using Atomic.Elements;
using GameEngine.Actions;
using Systems;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class Weapon : IDisposable
    {
        public IAtomicObservable FireEvent => fireEvent;
        public IAtomicAction FireAction => fireAction;

        [SerializeField] private Transform firePoint;
        [SerializeField] private SpawnBulletAction fireAction = new();
        [SerializeField] private AtomicEvent fireEvent = new();

        public void Compose(BulletSystem bulletSystem)
        {
            fireAction.Compose(bulletSystem, firePoint, fireEvent);
        }

        public void Dispose()
        {
            fireEvent?.Dispose();
        }
    }
}