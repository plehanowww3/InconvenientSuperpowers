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

        public HealthData()
        {
            SetData(this);
        }
        public HealthData(int _addMaxHp, int _addRenegHp, float _addRegenRate, int _instaHeal)
        {
            SetData(this);
            AddMaxHp = _addMaxHp;
            AddRegenHp = _addRenegHp;
            AddRegenRate = _addRegenRate;
            InstaHeal = _instaHeal;
        }
    }
}