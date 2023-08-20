using System;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class AttackData: EffectData
    {
        public int AddDamage;
        public float AddAttackSpeed;
        public float AddRadius;
        public float Range;

        public AttackData()
        {
             SetData(this);
        }
        public AttackData(int _addDamage, float _addAttackSpeed, float _addRadius, float _addRange)
        {
            SetData(this);
            AddDamage = _addDamage;
            AddAttackSpeed = _addAttackSpeed;
            AddRadius = _addRadius;
            Range = _addRange;
        }
    }
}