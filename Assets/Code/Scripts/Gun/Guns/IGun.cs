public interface IGun
{
    public IGunMover Mover { get; }
    public IGunSound Sound { get; }
    public IAmmunitionsSpawner Spawner { get; }
    public IGunView View { get; }
}