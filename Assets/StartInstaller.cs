using DefaultNamespace.MVVM;
using DefaultNamespace.MVVM.ViewModel;
using UnityEngine;
using Zenject;

public class StartInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Model>().AsSingle().NonLazy();
        
        Container.Bind<CurrenciesViewModel>().AsSingle().NonLazy();
    }
}