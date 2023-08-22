using System;
using DefaultNamespace.MVVM.ViewModel;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class EffectData
    {
        public EffectData Instance;

        private EffectsViewModel m_effectViewModel;

        [Inject]
        public void InjectViewModel(EffectsViewModel _effectsViewModel)
        {
            m_effectViewModel = _effectsViewModel;
        }
        
        public void SetData(EffectData _effectData)
        {
            Instance = _effectData;
        }
        
        public void Upgrade()
        {
            if (Instance != null)
                m_effectViewModel.AddBuff.Execute(Instance);
        }
    }
}