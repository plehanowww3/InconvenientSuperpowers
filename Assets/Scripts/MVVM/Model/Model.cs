using System.Collections.Generic;
using DefaultNamespace.Data;

namespace DefaultNamespace.MVVM
{
    public class Model
    {
        public int m_gold = 5;
        public int m_experience;
        public int m_currenLvl = 1;
        
        public List<EffectData> m_currentEffects = new List<EffectData>();
    }
}