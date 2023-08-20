using System;
using UnityEngine;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class EffectData
    {
        public EffectData Instance;

        public void SetData(EffectData _effectData)
        {
            Instance = _effectData;
        }
        
        public void Upgrade()
        {
            if (Instance != null)
                GameManager.instance.Upgrade(Instance);
        }
    }
}