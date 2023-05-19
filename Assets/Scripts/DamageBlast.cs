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
        [SerializeField] private List<AudioClip> m_blastSounds;
        private bool m_hiited;
        
        public void CreateDamage(int _damage, float _radius, List<EffectData> _attackEffects)
        {
            Collider2D[] hittedColliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (var collider in hittedColliders)
            {
                if (!m_hiited)
                {
                    var randomSoundNumber = Random.Range(0, m_blastSounds.Count);
                    AudioSource.PlayClipAtPoint(m_blastSounds[randomSoundNumber], transform.position);
                }
                    
                var health = collider.GetComponent<Health>();
                
                if (health)
                    health.TakeDamage(_damage);

                foreach (var effect in _attackEffects)
                {
                    switch (effect)
                    {
                        case FrostData:
                            var freezeData = _attackEffects.OfType<FrostData>().FirstOrDefault();
                            if (IsEffectChance(freezeData.AddHitPercent) && !collider.GetComponent<FreezeEffect>())
                            {
                                collider.AddComponent<FreezeEffect>().InitFreezable(freezeData);
                                var effectObj = Instantiate(Resources.Load<ParticleSystem>("Effects/FreezeEffect"));
                                Destroy(effectObj, freezeData.Duration);
                                effectObj.transform.parent = collider.transform;
                                effectObj.transform.localScale = new Vector3(1, 1, 1);
                            }
                            break;
                        case FiringData:
                            var firingData = _attackEffects.OfType<FiringData>().FirstOrDefault();
                            if (IsEffectChance(firingData.AddHitPercent) && !collider.GetComponent<FireEffect>())
                            {
                                collider.AddComponent<FireEffect>().InitFiring(firingData);
                                var effectObj = Instantiate(Resources.Load<ParticleSystem>("Effects/FireEffect"));
                                Destroy(effectObj, firingData.Duration);
                                effectObj.transform.parent = collider.transform;
                                effectObj.transform.localScale = new Vector3(1, 1, 1);
                            }
                            break;
                    }
                }
            }
        }

        private bool IsEffectChance(float _baseChance)
        {
            var chance = Random.Range(0, 100f);
            return chance <= _baseChance;
        }
    }
}