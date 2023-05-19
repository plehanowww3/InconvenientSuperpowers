using System.Collections.Generic;
using DefaultNamespace.Data;
using DefaultNamespace.ViewsUi;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private AudioClip m_lvlUpAudio;
        [SerializeField] private TMP_Text m_lvlText;
        [SerializeField] private Image m_expFillerImage;
        [SerializeField] private Image m_healthFillerImage;
        [SerializeField] private Button m_addExpButton;
        [SerializeField] private SkillHolderView m_skillHolderView;

        private List<int> lvlsExp = new List<int>();
        private int m_currentLvl = 1;
        private int m_currentExp = 0;
        
        public static GameManager instance;
        public CameraShake m_shakeCamera;
        public Transform m_PlayerTransform;
        public PlayerScript m_playerScript;
        
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);

            lvlsExp.Add(50);
            for (int i = 1; i < 50; i++)
            {
                var currentLvlExp = lvlsExp[i - 1] + i * 15;
                lvlsExp.Add(currentLvlExp);
            }
            
            m_addExpButton.onClick.AddListener(() => AddExpirience(10));
        }

        public void Upgrade(EffectData _effectData) => m_playerScript.AddEffect(_effectData);

        public void AddExpirience(int _value)
        {
            if (m_currentExp + _value > lvlsExp[m_currentLvl + 1])
            {
                var lastExp = m_currentExp + _value - lvlsExp[m_currentLvl + 1];
                
                m_currentExp += _value - lastExp;
                m_currentLvl++;
                
                AudioSource.PlayClipAtPoint(m_lvlUpAudio, GameManager.instance.m_PlayerTransform.position);
                m_skillHolderView.ShowPanel();
                AddExpirience(lastExp);
                return;
            }
            
            m_currentExp += _value;
            m_expFillerImage.fillAmount = 1f * m_currentExp / lvlsExp[m_currentLvl + 1];
            m_lvlText.text = m_currentLvl.ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}