public static class AssetProvider
{
    public const string Bullet = nameof(Bullet);

    #region Sounds
    public const string Shoot = nameof(Shoot);
    #endregion

    #region Guns
    public const string PrefabDeagle = nameof(PrefabDeagle);
    public const string PrefabSawed = nameof(PrefabSawed);
    #endregion

    #region Particles
    public const string ParticleShoot = nameof(ParticleShoot);
    #endregion

    #region Character
    public enum Character
    {
        PlayerSawedGun,
        PlayerDeagle
    }
    #endregion
}