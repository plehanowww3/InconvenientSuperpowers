using System.Collections.Generic;
using DefaultNamespace.Data;
using DefaultNamespace.MVVM.ViewModel;
using DefaultNamespace.ViewsUi;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public static class GameManager
    {
        private static EffectsViewModel m_effectsViewModel;

        [Inject]
        public static void Init(EffectsViewModel _effectsViewModel)
        {
            m_effectsViewModel = _effectsViewModel;
        }
    }
}