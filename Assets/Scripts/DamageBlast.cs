using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Data;
using DefaultNamespace.Interfaces;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageBlast: MonoBehaviour
    {
        public void CreateDamage(int _damage, float _radius, List<IEffectData> _attackEffects)
        {
            Collider2D[] hittedColliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (var collider in hittedColliders)
            {
                var health = collider.GetComponent<Health>();
                
                if (health)
                    health.TakeDamage(_damage);

                foreach (var effect in _attackEffects)
                {
                    switch (effect)
                    {
                        case FreezeData:
                            var freezeData = _attackEffects.OfType<FreezeData>().FirstOrDefault();
                            collider.AddComponent<FreezeEffect>().InitFreezable(freezeData);
                            break;
                        case FiringData:
                            var firingData = _attackEffects.OfType<FiringData>().FirstOrDefault();
                            collider.AddComponent<FireEffect>().InitFiring(firingData);
                            break;
                    }
                }
            }
        }
    }
}