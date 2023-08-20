using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Data;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Abstract
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "ScriptableObjects/EffectData", order = 2)]
    public class SkillScriptableObjectAbstract : ScriptableObject
    {
        public string Name;
        [TextArea] public string Description;
        public string SkillId;
        public string Level;

        public EffectsEnum n_effectsEnum;

        [SerializeReference] 
        public List<EffectData> m_effects;
        
        [ContextMenu("AddEffect")]
        private void AddEffect()
        {
            switch (n_effectsEnum)
            {
                case EffectsEnum.FIRE:
                    CheckForData<FiringData>(new FiringData());
                    break;
                case EffectsEnum.ATTACK:
                    CheckForData<AttackData>(new AttackData());
                    break;
                case EffectsEnum.HEALTH:
                    CheckForData<HealthData>(new HealthData());
                    break;
                case EffectsEnum.FROST:
                    CheckForData<FrostData>(new FrostData());
                    break;
            }
        }

        public void Upgrade()
        {
            foreach (var effect in m_effects)
                effect.Upgrade();
        }
        
        private void OnEnable()
        {
            if (m_effects == null)
                m_effects = new List<EffectData>();
        }
        
        private void CheckForData<T>(EffectData _dataType)
        {
            if (!m_effects.OfType<T>().Any())
                m_effects.Add(_dataType);
        }
    }
}