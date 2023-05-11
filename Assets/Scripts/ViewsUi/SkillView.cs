using System;
using DefaultNamespace.Data;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace.ViewsUi
{
    public class SkillView: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_header;
        [SerializeField] private TMP_Text m_description;
        [SerializeField] private Button m_upgradeButton;
        [SerializeField] private AttackDataObject m_skillObject;

        private void Awake()
        {
            m_upgradeButton.onClick.AddListener(Upgrade);
        }

        public void Init(SkillUiData _uiData)
        {
            m_header.text = _uiData.m_header;
            m_description.text = _uiData.m_description;
        }

        private void Upgrade() => m_skillObject.Upgrade();
    }
}