using System;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public class FireEffect: MonoBehaviour, IEffect
    {
        [SerializeField] private ParticleSystem m_effect;
        private FiringData m_firingData;

        public void InitFiring(FiringData _data)
        {
            m_firingData = _data;
        }

        private void Start()
        {
            InvokeRepeating("StartEffect", m_firingData.Delay,m_firingData.FlameRate);
            StopEffect();
        }

        public void StartEffect()
        {
            transform.GetComponent<IHealth>().DecreaseHealth(m_firingData.FlameDamage);
        }

        public void StopEffect()
        {
            Destroy(this, m_firingData.Duration);
        }
    }
}