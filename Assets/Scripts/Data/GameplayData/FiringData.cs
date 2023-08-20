using System;
using UnityEngine;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class FiringData: EffectData
    {
        public float Delay;
        public float Duration;
        public float FlameRate;
        public int FlameDamage;
        public float AddHitPercent;
        public ParticleSystem ParticleSystem;

        public FiringData()
        {
            SetData(this);
        }
        public FiringData(float _delay, float _duration, float _rate, int _damage, float _hitPercent)
        {
            SetData(this);
            Delay = _delay;
            Duration = _duration;
            FlameRate = _rate;
            FlameDamage = _damage;
            AddHitPercent = _hitPercent;
            ParticleSystem = null;
        }
    }
}