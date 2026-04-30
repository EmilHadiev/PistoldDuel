using Zenject;

public class LocalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindFactory();
    }

    private void BindFactory()
    {
        Container.BindInterfacesTo<Factory>().AsSingle();
    }

    private void BindInput()
    {
        Container.BindInterfacesTo<InputService>().AsSingle();
    }
}