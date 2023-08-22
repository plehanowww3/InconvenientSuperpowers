using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Data;
using DefaultNamespace.MVVM.ViewModel;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerScript: MonoBehaviour
    {
        [SerializeField] private CharacterController2D m_characterController2D;
        [SerializeField] private float m_runSpeed;
        [SerializeField] private DamageBlast m_damageBlast;

        private Health m_health;
        private PlayerStats m_playerStats;
        
        private Animator m_animator;
        private Rigidbody2D m_rigidbody;
        private float m_horizontalMove;
        
        private bool m_jump = false;
        private bool m_croach = false;
        private bool m_inAir = false;

        private List<EffectData> m_currentEffects = new List<EffectData>();

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
            m_health = GetComponent<Health>();
            
        }
        
        [Inject]
        public void Init(PlayerStats _playerStats)
        {
            m_playerStats = new PlayerStats();
        }

        public void SetInAirStatus()
        {
            m_inAir = true;
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
            m_damageBlast.CreateDamage(m_playerStats.m_damage, 0.5f, m_currentEffects);
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