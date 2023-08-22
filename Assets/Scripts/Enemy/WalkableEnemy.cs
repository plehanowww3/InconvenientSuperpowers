using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public class WalkableEnemy: MonoBehaviour
    {
        [SerializeField] private int m_gainExp;
        [SerializeField] private float m_distanceToGo;
        [SerializeField] private float m_distanceToAttack;
        [SerializeField] private Animator m_animator;
        private const float ForcePower = 10f;

        public new Rigidbody2D rigidbody;

        public float speed = 2f;
        public float force = 2f;

        private Vector2 direction;
        private Transform m_playerTransform;

        private void Start()
        {
           // m_playerTransform = GameManager.instance.m_PlayerTransform;
        }

        public void MoveTo (Vector2 direction) 
        {
            this.direction = direction;
        }

        public void Stop() 
        {
            MoveTo(Vector2.zero);
        }

        private void FixedUpdate() 
        {
            /*if (Vector2.Distance(gameObject.transform.position, m_playerTransform.position) <= m_distanceToGo)
            {
                var desiredVelocity = (Vector2)(m_playerTransform.position - transform.position) * speed;
                var deltaVelocity = desiredVelocity - rigidbody.velocity;
                Vector3 moveForce = deltaVelocity * (force * ForcePower * Time.fixedDeltaTime);
                rigidbody.AddForce(moveForce);
                
                if (Vector2.Distance(gameObject.transform.position, m_playerTransform.position) <= m_distanceToAttack)
                {
                    
                }
            }*/
        }
    }
}