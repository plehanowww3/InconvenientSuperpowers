using DefaultNamespace;
using DefaultNamespace.Data;
using Interfaces;

namespace ScriptableObjects
{
    public class EffectDataAbstract: EffectScriptableObject
    {
        public EffectData m_effectData;

        public void Upgrade()
        {
            GameManager.instance.Upgrade(m_effectData);
        }
    }
}