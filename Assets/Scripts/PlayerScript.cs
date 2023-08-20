using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Data;
using UnityEngine;

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
        
        private int m_damage = 5;
        private float m_attackRaduis = 1;
        private float m_attackRange;
        private float m_attackSpeed;

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
            
            GameManager.instance.m_PlayerTransform = transform;
            GameManager.instance.m_playerScript = this;
        }

        public void AddEffect(EffectData _effect)
        {
            EffectData newEffect = null;
            
            switch (_effect)
            {
                case AttackData:
                    AddDamageEffect((AttackData) _effect);
                    return;
                case HealthData:
                    AddHealthEffect((HealthData) _effect);
                    return;
                
                case FiringData:
                    newEffect = (FiringData) _effect;
                    break;
                case FrostData:
                    newEffect = (FrostData) _effect;
                    break;
            }
            if (m_currentEffects.OfType<FiringData>().Any())
            {
                var index = m_currentEffects.IndexOf(newEffect);
                m_currentEffects[index] = newEffect;
                return;
            }
     
            m_currentEffects.Add(newEffect);
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
            GameManager.instance.m_shakeCamera.Shake();
            m_damageBlast.CreateDamage(m_damage, 0.5f, m_currentEffects);
        }

        private void AddDamageEffect(AttackData _attackData)
        {
            m_damage += _attackData.AddDamage;
            m_attackSpeed += _attackData.AddAttackSpeed;
            m_attackRaduis += _attackData.AddRadius;
        }
        
        private void AddHealthEffect(HealthData _healthData)
        {
            m_health.IncreaseMaxHealth(_healthData.AddMaxHp);
            m_health.IncreaseHealth(_healthData.InstaHeal);
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