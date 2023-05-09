using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement: MonoBehaviour
    {
        [SerializeField] private CharacterController2D m_characterController2D;
        [SerializeField] private float m_runSpeed;
        [SerializeField] private DamageBlast m_damageBlast;

        private Animator m_animator;
        private Rigidbody2D m_rigidbody;
        private float m_horizontalMove;
        private bool m_jump = false;
        private bool m_croach = false;
        private bool m_inAir = false;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }

        private void Update()
        {
            m_horizontalMove = Input.GetAxisRaw("Horizontal") * m_runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                m_animator.SetTrigger("Jump");
                m_jump = true;
            }
            
            if (Input.GetKeyDown(KeyCode.LeftAlt))
                m_croach = true;
            
            if (Input.GetMouseButtonDown(0))
                m_animator.SetTrigger("Punch");
        }

        public void CreateDamageBlast()
        {
            m_damageBlast.CreateDamage(5, 0.5f);
        }

        public void SetInAirStatus()
        {
            m_inAir = true;
        }

        private void FixedUpdate()
        {
            m_characterController2D.Move(m_horizontalMove * Time.fixedDeltaTime, m_croach, m_jump);
            m_animator.SetFloat("Speed", m_horizontalMove*m_horizontalMove);
            if (m_characterController2D.m_onGround && m_inAir)
            { 
                m_animator.SetTrigger("Landing");
                m_inAir = false;
            }

            m_jump = false;
        }
    }
}