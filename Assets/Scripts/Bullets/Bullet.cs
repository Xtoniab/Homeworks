using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public TeamTag TeamTag { get; private set; }
        public int Damage { get; private set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.OnCollisionEntered?.Invoke(this, collision);
        }
        
        public void SetTeamTag(TeamTag teamTag)
        {
            this.TeamTag = teamTag;
        }
        
        public void SetDamage(int damage)
        {
            if (damage >= 0)
            {
                this.Damage = damage;
            }
            else
            {
                throw new ArgumentException("Damage can't be negative");
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }
    }
}