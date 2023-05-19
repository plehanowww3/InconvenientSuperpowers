using System;
using DefaultNamespace.Abstract;
using DefaultNamespace.Data;
using DefaultNamespace.ScriptableObjects;
using Interfaces;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace.ViewsUi
{
    public class SkillView: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_header;
        [SerializeField] private TMP_Text m_description;
        [SerializeField] public Button m_upgradeButton;
        [SerializeField] private SkillScriptableObjectAbstract m_skillObject;
        [SerializeField] private SkillHolderView m_skillViewHolder;
        [SerializeField] private AudioClip m_selectedSkillAudio;

        private EffectScriptableObject m_upgradeScript;

        private void Awake()
        {
            m_upgradeButton.onClick.AddListener(Upgrade);
        }

        public void Init(SkillScriptableObjectAbstract _skillObject)
        {
            m_skillObject = _skillObject;
            m_header.text = m_skillObject.Name;
            m_description.text = m_skillObject.Description;
            m_upgradeScript = (EffectScriptableObject)m_skillObject;
        }

        private void Upgrade()
        {
            m_upgradeScript.Upgrade();
            m_skillViewHolder.ClosePanel();
            m_skillViewHolder.RemoveSkillFromList(m_skillObject);
            AudioSource.PlayClipAtPoint(m_selectedSkillAudio, GameManager.instance.m_PlayerTransform.position);
        }
    }
}