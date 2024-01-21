using System;
using Atomic.Objects;
using GameEngine.Actions;
using Systems;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class WeaponComponent
    {
        [SerializeField] private Transform firePoint;
        [Get(ObjectApi.FireAction), SerializeField] private FireAction fireAction = new();
        
        public void Compose(BulletSystem bulletSystem)
        {
            fireAction.Compose(bulletSystem, firePoint);
        }
    }
}