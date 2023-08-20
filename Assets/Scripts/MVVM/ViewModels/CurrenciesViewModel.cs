using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.MVVM.ViewModel
{
    public class CurrenciesViewModel
    {
        private Model m_model;
        public ReactiveCommand<int> IncreaseGold;
        public ReactiveCommand<int> DecreaseGold;

        [Inject]
        public CurrenciesViewModel(Model _model)
        {
            m_model = _model;
            Debug.Log($"{this.GetType()} " + _model.m_gold);
        }

        private void IncreaseGoldAction(int _increaseCount)
        {
            m_model.m_gold = Math.Clamp(_increaseCount, 0, int.MaxValue);
        }
        
        private void DecreaseGoldAction(int _decreseCount)
        {
            m_model.m_gold = Math.Clamp(-_decreseCount, 0, int.MaxValue);
        }
    }
}