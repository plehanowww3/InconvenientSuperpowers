using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Data;
using UniRx;
using Zenject;

namespace DefaultNamespace.MVVM.ViewModel
{
    public class EffectsViewModel
    {
        private Model m_model;
        public ReactiveCommand<EffectData> AddBuff;
        public ReactiveCommand<EffectData> DeleteBuff;
        
        private List<EffectData> m_currentEffects = new List<EffectData>();
        private PlayerScript m_playerScript;
        private PlayerStats m_playerStats;
        
        [Inject]
        public EffectsViewModel(Model _model, PlayerScript _playerScript, PlayerStats _playerStats)
        {
            m_model = _model;
            m_playerScript = _playerScript;
            m_playerStats = _playerStats;

            AddBuff = new ReactiveCommand<EffectData>();
            DeleteBuff = new ReactiveCommand<EffectData>();

            AddBuff.Subscribe(AddEffect);
        }
        
        public void AddEffect(EffectData _effect)
        {
            EffectData newEffect = null;
            
            switch (_effect)
            {
                case AttackData:
                    m_playerStats.AddDamageEffect((AttackData) _effect);
                    return;
                case HealthData:
                    m_playerStats.AddHealthEffect((HealthData) _effect);
                    return;
                case FiringData:
                    newEffect = (FiringData) _effect;
                    break;
                case FrostData:
                    newEffect = (FrostData) _effect;
                    break;
            }
            if (m_currentEffects.OfType<FiringData>().Any())
            {
                var index = m_currentEffects.IndexOf(newEffect);
                m_currentEffects[index] = newEffect;
                return;
            }
     
            m_currentEffects.Add(newEffect);
        }
    }
}