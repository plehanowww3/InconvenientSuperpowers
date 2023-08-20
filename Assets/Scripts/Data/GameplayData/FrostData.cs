using System;
using UnityEngine;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class FrostData: EffectData
    {
        public float Delay;
        public float Duration;
        public float FreezeIndex;
        public float AddHitPercent;
        public ParticleSystem ParticleSystem;

        public FrostData()
        {
            SetData(this);
        }
        public FrostData(float _delay, float _duration, float _freezeIndex, float _hitPercent)
        {
            SetData(this);
            Delay = _delay;
            Duration = _duration;
            FreezeIndex = _freezeIndex;
            AddHitPercent = _hitPercent;
            ParticleSystem = null;
        }
    }
}