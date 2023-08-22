using DefaultNamespace.Data;

namespace DefaultNamespace.MVVM.ViewModel
{
    public class PlayerStats
    {
        public Health m_health;
        
        public int m_damage { get; private set; } //5
        public float m_attackRaduis { get; private set; } //1
        public float m_attackRange { get; private set; }
        public float m_attackSpeed { get; private set; }

        public void AddDamageEffect(AttackData _attackData)
        {
            m_damage += _attackData.AddDamage;
            m_attackSpeed += _attackData.AddAttackSpeed;
            m_attackRaduis += _attackData.AddRadius;
        }
        
        public void AddHealthEffect(HealthData _healthData)
        {
            m_health.IncreaseMaxHealth(_healthData.AddMaxHp);
            m_health.IncreaseHealth(_healthData.InstaHeal);
        }
    }
}