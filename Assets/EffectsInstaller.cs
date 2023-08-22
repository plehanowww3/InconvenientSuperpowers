using System.Collections.Generic;
using DefaultNamespace.Abstract;
using DefaultNamespace.Data;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EffectsInstaller", menuName = "Installers/EffectsInstaller")]
public class EffectsInstaller : ScriptableObjectInstaller<EffectsInstaller>
{
    private const string PATH_THO_EFFECTS = "Assets/ScriptableObjects";
    [SerializeField] private List<SkillScriptableObjectAbstract> m_effectsObjects;

    public override void InstallBindings()
    {
        foreach (var effectObject in m_effectsObjects)
            Container.InstantiateScriptableObjectResource<SkillScriptableObjectAbstract>(PATH_THO_EFFECTS + effectObject.name);
    }
}