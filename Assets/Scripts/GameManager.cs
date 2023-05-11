using System.Collections.Generic;
using DefaultNamespace.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_lvlText;
        [SerializeField] private Image m_expFillerImage;
        [SerializeField] private Image m_healthFillerImage;
        
        private List<int> lvlsExp = new List<int>();
        private int m_currentLvl = 0;
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
        }

        public void Upgrade(IEffectData _effectData) => m_playerScript.AddEffect(_effectData);

        public void AddExpirience(int _value)
        {
            m_currentExp += _value;
            while (m_currentExp < lvlsExp.Count && m_currentExp >= lvlsExp[m_currentLvl - 1]) 
            {
                m_currentExp -= lvlsExp[m_currentLvl - 1];
                m_currentLvl++;
            }

            m_lvlText.text = m_currentLvl.ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}