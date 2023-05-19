using System;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class HealthData: EffectData
    {
        public int AddMaxHp;
        public int AddRegenHp;
        public float AddRegenRate;
        public int InstaHeal;
        
        public HealthData() { }
        public HealthData(int _addMaxHp, int _addRenegHp, float _addRegenRate, int _instaHeal)
        {
            AddMaxHp = _addMaxHp;
            AddRegenHp = _addRenegHp;
            AddRegenRate = _addRegenRate;
            InstaHeal = _instaHeal;
        }
    }
}