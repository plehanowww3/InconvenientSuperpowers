using System;
using DefaultNamespace.Abstract;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "ScriptableObjects/HealthData", order = 4)]

    public class HealthDataObject: ScriptableObject, EffectScriptableObject
    {
        public HealthData m_healthData;
        
        public void Upgrade()
        {
            GameManager.instance.Upgrade(m_healthData);
        }
    }
}