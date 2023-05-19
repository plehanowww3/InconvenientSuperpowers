using DefaultNamespace.Abstract;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FreezeData", menuName = "ScriptableObjects/FreezeData", order = 1)]
    public class FreezeDataObject: ScriptableObject, EffectScriptableObject
    {
        public FrostData m_frostDataObject;
        
        public void Upgrade()
        {
            GameManager.instance.Upgrade(m_frostDataObject);
        }
    }
}