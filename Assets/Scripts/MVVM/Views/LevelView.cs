using System;
using DefaultNamespace.MVVM.ViewModel;
using DefaultNamespace.ViewsUi;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.MVVM.Views
{
    public class LevelView: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_lvlText;
        [SerializeField] private Image m_expFillerImage;
        [SerializeField] private Image m_healthFillerImage;
        [SerializeField] private Button m_addExpButton;
        [SerializeField] private SkillHolderView m_skillHolderView;
        
        [Inject]
        private ExperienceViewModel m_experienceViewModel;
        
        private void Awake()
        {
            m_addExpButton.onClick.AddListener(() => m_experienceViewModel.AddExpirience(10));

            m_experienceViewModel.m_currenLvl.Subscribe(ChangeLvl);
            m_experienceViewModel.m_visibleExp.Subscribe(ChangeExpLine);
        }

        [Inject]
        private void Construct(ExperienceViewModel _experienceViewModel)
        {
            m_experienceViewModel = _experienceViewModel;
        }

        private void ChangeLvl(int _currenLvl)
        {
            m_lvlText.text = _currenLvl.ToString();
        }

        private void ChangeExpLine(int _currentExp)
        {
            m_expFillerImage.fillAmount = 1f * _currentExp / m_experienceViewModel.nextLvlExp;
        }
    }
}