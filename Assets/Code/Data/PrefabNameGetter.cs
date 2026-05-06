public class PrefabNameGetter
{
    private const string PlayerPrefix = "Player";
    private const string PrefabPrefix = "Prefab";

    public string GetGunPrefab(AssetProvider.Character character)
    {
        string charName = character.ToString();

        if (charName.StartsWith(PlayerPrefix))
        {
            return PrefabPrefix + charName.Substring(PlayerPrefix.Length);
        }

        return AssetProvider.PrefabDeagle;
    }
}