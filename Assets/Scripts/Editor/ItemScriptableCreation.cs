#if UNITY_EDITOR
using Prueba.Inventory;
using UnityEditor;
using UnityEngine;

public static class ItemScriptableCreation
{
    [MenuItem("Prueba/AddItem/Resources")]
    public static void CreateResourceItem()
    {
        ResourceItemScriptable asset = ScriptableObject.CreateInstance<ResourceItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableItems/NewResourceItem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Consumables")]
    public static void CreateConsumableItem()
    {
        ConsumableItemScriptable asset = ScriptableObject.CreateInstance<ConsumableItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableItems/NewConsumableItem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Trash")]
    public static void CreateTrashItem()
    {
        TrashItemScriptable asset = ScriptableObject.CreateInstance<TrashItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableItems/NewTrashItem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Weapon")]
    public static void CreateWeaponItem()
    {
        WeaponItemScriptable asset = ScriptableObject.CreateInstance<WeaponItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableItems/NewWeaponItem.asset");
        AssetDatabase.SaveAssets();
    }
}
#endif
