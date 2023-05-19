using System;
using DefaultNamespace.Data;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public class FreezeEffect: MonoBehaviour, IEffect
    {
        private FrostData _frostData;

        public void InitFreezable(FrostData _data)
        {
            _frostData = _data;
        }

        private void Start()
        {
            Invoke("StartEffect", _frostData.Delay);
            Invoke("StopEffect", _frostData.Duration);
        }

        public void StartEffect()
        {
            transform.GetComponent<IMovable>().DecreaseMoveSpeed(_frostData.FreezeIndex);
        }

        public void StopEffect()
        {
            transform.GetComponent<IMovable>().IncreaseMoveSpeed(_frostData.FreezeIndex);
            Destroy(this);
        }
    }
}