using System;
using Pool;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : PoolObject
    {
        public event Action<Bullet> OnHit;

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private TeamTag teamTag;
        private int damage;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            TryDealDamage(collision.gameObject);
        }

        private bool TryDealDamage(GameObject target)
        {
            if (!target.TryGetComponent(out TeamComponent team))
            {
                return false;
            }

            if (this.teamTag == team.TeamTag)
            {
                return false;
            }

            if (target.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(this.damage);
            }
            
            OnHit?.Invoke(this);

            return true;
        }


        public void SetDamage(int damage)
        {
            if (damage >= 0)
            {
                this.damage = damage;
            }
            else
            {
                throw new ArgumentException("Damage can't be negative");
            }
        }
        
        public void SetTeamTag(TeamTag teamTag) => this.teamTag = teamTag;
        public void SetVelocity(Vector2 velocity) => this.rigidbody2D.velocity = velocity;
        public void SetPhysicsLayer(int physicsLayer) => this.gameObject.layer = physicsLayer;
        public void SetPosition(Vector3 position) => this.transform.position = position;
        public void SetColor(Color color) => this.spriteRenderer.color = color;
    }
}