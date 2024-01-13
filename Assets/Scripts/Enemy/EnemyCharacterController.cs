using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCharacterController : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private EnemyAttackAgent attackAgent;

        public Transform AttackPosition { get; private set; }

        public void Construct(Transform attackPosition, GameObject attackTarget)
        {
            this.AttackPosition = attackPosition;
            this.moveAgent.SetDestination(attackPosition.position);
            this.attackAgent.SetTarget(attackTarget);
            this.attackAgent.ResetCooldown();
        }

        private void FixedUpdate()
        {
            if (!moveAgent.IsReached)
            {
                character.Move(moveAgent.GetMoveDirection());
            }
            else
            {
                attackAgent.FixedTick();
            }
        }

        private void OnEnable()
        {
            attackAgent.OnFire += FirePlayer;
        }

        private void OnDisable()
        {
            attackAgent.OnFire -= FirePlayer;
        }

        private void FirePlayer(GameObject target)
        {
            character.FireTarget(target);
        }
    }
}