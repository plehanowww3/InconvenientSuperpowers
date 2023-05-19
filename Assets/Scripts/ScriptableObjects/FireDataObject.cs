using DefaultNamespace.Abstract;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FireData", menuName = "ScriptableObjects/FireData", order = 2)]

    public class FireDataObject: ScriptableObject, EffectScriptableObject
    {
        public FiringData m_fireData;
       
        public void Upgrade()
        {
            GameManager.instance.Upgrade(m_fireData);
        }
    }
}