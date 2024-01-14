using Pool;
using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : PoolObject
    {
        [SerializeField] private ShipComponent shipComponent;
        [SerializeField] private MoveAgent moveAgent;
        [SerializeField] private AttackAgent attackAgent;

        private AttackPositionHandle attackPositionHandle;
        
        public void Construct(AttackPositionHandle attackPositionHandle, GameObject attackTarget)
        {
            this.attackPositionHandle = attackPositionHandle;
            
            this.moveAgent.SetDestination(attackPositionHandle.Value);
            this.attackAgent.SetTarget(attackTarget);
            this.attackAgent.ResetCooldown();
        }

        private void FixedUpdate()
        {
            if (!this.moveAgent.IsReached)
            {
                this.shipComponent.Move(moveAgent.GetMoveDirection());
            }
            else
            {
                this.attackAgent.FixedTick();
            }
        }

        private void OnEnable()
        {
            this.attackAgent.OnFire += FirePlayer;
            this.shipComponent.OnDeath += PoolSelf;
            this.shipComponent.OnDeath += this.attackPositionHandle.Release;
        }

        private void OnDisable()
        {
            this.attackAgent.OnFire -= FirePlayer;
            this.shipComponent.OnDeath -= PoolSelf;
            this.shipComponent.OnDeath -= this.attackPositionHandle.Release;
        }

        public override void Reset()
        {
            this.shipComponent.Reset();
        }

        private void FirePlayer(GameObject target)
        {
            this.shipComponent.FireTarget(target);
        }
    }
}