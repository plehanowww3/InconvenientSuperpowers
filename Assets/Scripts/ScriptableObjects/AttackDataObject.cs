using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 3)]
    public class AttackDataObject: ScriptableObject, ISkillUpgrade
    {
        public AttackData m_attackData;

        public void Upgrade()
        {
            
        }
    }
}