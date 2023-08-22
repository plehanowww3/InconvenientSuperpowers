using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.MVVM.ViewModel
{
    public class ExperienceViewModel
    {
        private Model m_model;

        public ReactiveCommand<int> AddExp;
        public ReactiveCommand<int> IncreaseExp;
        public ReactiveCommand ShowLvlUpRewards;

        public ReactiveProperty<int> m_currenLvl;
        public ReactiveProperty<int> m_visibleExp;

        public int nextLvlExp { get; private set; }

        private List<int> lvlsExp = new List<int>();

        [Inject]
        public ExperienceViewModel(Model _model)
        {
            m_model = _model;

            AddExp = new ReactiveCommand<int>();
            IncreaseExp = new ReactiveCommand<int>();
            
            ShowLvlUpRewards = new ReactiveCommand();
            
            m_currenLvl = new ReactiveProperty<int>(1);
            m_visibleExp = new ReactiveProperty<int>();
            
            lvlsExp.Add(50);
            for (int i = 1; i < 50; i++)
            {
                var currentLvlExp = lvlsExp[i - 1] + i * 15;
                lvlsExp.Add(currentLvlExp);
            }
        }
        
        public void AddExpirience(int _value)
        {
            nextLvlExp = lvlsExp[m_model.m_currenLvl + 1];
            
            if (m_model.m_experience + _value > lvlsExp[m_model.m_currenLvl + 1])
            {
                var lastExp = m_model.m_experience + _value - lvlsExp[m_model.m_currenLvl + 1];
                
                m_model.m_experience += _value - lastExp;
                m_currenLvl.Value++;
                m_model.m_experience = 0;
                m_visibleExp.Value = m_model.m_experience;
                
                //AudioSource.PlayClipAtPoint(m_lvlUpAudio, instance.m_PlayerTransform.position);
                ShowLvlUpRewards.Execute();
                AddExpirience(lastExp);
                return;
            }
            
            m_model.m_experience += _value;
            m_visibleExp.Value = m_model.m_experience;
        }
    }
}