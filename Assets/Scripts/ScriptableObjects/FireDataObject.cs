using DefaultNamespace.Data;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FireData", menuName = "ScriptableObjects/FireData", order = 2)]

    public class FireDataObject: ScriptableObject
    {
        public FiringData m_fireData;
    }
}