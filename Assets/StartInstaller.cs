using DefaultNamespace;
using DefaultNamespace.MVVM;
using DefaultNamespace.MVVM.ViewModel;
using DefaultNamespace.MVVM.Views;
using UnityEngine;
using Zenject;

public class StartInstaller : MonoInstaller
{
    [SerializeField] private PlayerScript m_player;
    [SerializeField] private LevelView m_levelView;

    public void BindInterface()
    {
        Container.BindInstance(m_levelView);
    }
    public override void InstallBindings()
    {
        Container.Bind<Model>().AsSingle().NonLazy();
        
        Container.Bind<PlayerStats>().FromNew().AsSingle().NonLazy();
        Container.Bind<PlayerScript>().FromInstance(m_player).AsSingle().NonLazy();
        Container.QueueForInject(m_player);

        BindViewModels();
        BindInterface();
    }

    private void BindViewModels()
    {
        Container.Bind<CurrenciesViewModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<ExperienceViewModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<EffectsViewModel>().FromNew().AsSingle().NonLazy();
    }
}