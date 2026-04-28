using Zenject;

public class LocalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        Container.BindInterfacesTo<InputService>().AsSingle();
    }
}