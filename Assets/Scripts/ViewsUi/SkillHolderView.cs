using System.Collections.Generic;
using DefaultNamespace.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.ViewsUi
{
    public class SkillHolderView: MonoBehaviour
    {
        [SerializeField] private SkillView[] m_skillsView;
        [SerializeField] private Animator m_animator;

        [SerializeField] private List<SkillScriptableObjectAbstract> m_skills;

        public void SetSkills()
        {
            foreach (var skillView in m_skillsView)
            {
                var randomQuest = Random.Range(0, m_skills.Count);
                skillView.Init(m_skills[randomQuest]);
            }
        }

        public void RemoveSkillFromList(SkillScriptableObjectAbstract _skill)
        {
            var skillNumber = m_skills.IndexOf(_skill);
            m_skills.Remove(m_skills[skillNumber]);
        }

        public void Deactive() => gameObject.SetActive(false);

        public void ShowPanel()
        {
            SetSkills();
            gameObject.SetActive(true);
            foreach (var skillView in m_skillsView)
                skillView.m_upgradeButton.interactable = true;
            
            m_animator.SetTrigger("OpenWindow");
        }
        
        public void ClosePanel()
        {
            foreach (var skillView in m_skillsView)
                skillView.m_upgradeButton.interactable = false;
            
            m_animator.SetTrigger("CloseWindow");
        }
    }
}