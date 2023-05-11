using DefaultNamespace.Data;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FreezeData", menuName = "ScriptableObjects/FreezeData", order = 1)]
    public class FreezeDataObject: ScriptableObject
    {
        public FreezeData m_freezeDataObject;
    }
}