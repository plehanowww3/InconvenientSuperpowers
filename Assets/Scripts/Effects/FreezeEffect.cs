using System;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public class FreezeEffect: MonoBehaviour, IEffect
    {
        [SerializeField] private ParticleSystem m_effect;
        private FreezeData m_freezeData;

        public void InitFreezable(FreezeData _data)
        {
            m_freezeData = _data;
        }

        private void Start()
        {
            Invoke("StartEffect", m_freezeData.Delay);
            Invoke("StopEffect", m_freezeData.Duration);
        }

        public void StartEffect()
        {
            transform.GetComponent<IMovable>().DecreaseMoveSpeed(m_freezeData.FreezeIndex);
        }

        public void StopEffect()
        {
            transform.GetComponent<IMovable>().IncreaseMoveSpeed(m_freezeData.FreezeIndex);
            Destroy(this);
        }
    }
}