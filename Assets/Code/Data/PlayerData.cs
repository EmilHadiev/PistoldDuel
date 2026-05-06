using UnityEngine;

[CreateAssetMenu(menuName = "CharacterData/PlayerData", fileName = "PlayerData")]
public class PlayerData : CharacterData
{
    [SerializeField] private AssetProvider.Character _charatcter;

    private PrefabNameGetter _nameGetter;

    private void Awake()
    {
        _nameGetter = new PrefabNameGetter();
    }

    public string GetGunPrefab()
    {
        return _nameGetter.GetGunPrefab(_charatcter);
    }

    public string GetPlayer()
    {
        return _charatcter.ToString();
    }
}