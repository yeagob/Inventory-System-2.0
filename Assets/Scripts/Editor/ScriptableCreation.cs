#if UNITY_EDITOR
using Prueba.Effects;
using Prueba.Inventory;
using UnityEditor;
using UnityEngine;

public static class ScriptableCreation
{
    [MenuItem("Prueba/AddEffect")]
    public static void CreateEffect()
    {
        EffectScriptable asset = ScriptableObject.CreateInstance<EffectScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scriptable Objects/Effects/NewEffect.asset");
        AssetDatabase.SaveAssets();
    }
    [MenuItem("Prueba/AddItem/Resources")]
    public static void CreateResourceItem()
    {
        ResourceItemScriptable asset = ScriptableObject.CreateInstance<ResourceItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scriptable Objects/Items/NewResourceItem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Consumables")]
    public static void CreateConsumableItem()
    {
        ConsumableItemScriptable asset = ScriptableObject.CreateInstance<ConsumableItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scriptable Objects/Items/NewConsumableItem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Trash")]
    public static void CreateTrashItem()
    {
        TrashItemScriptable asset = ScriptableObject.CreateInstance<TrashItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scriptable Objects/Items/Trash.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Prueba/AddItem/Weapon")]
    public static void CreateWeaponItem()
    {
        WeaponItemScriptable asset = ScriptableObject.CreateInstance<WeaponItemScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scriptable Objects/Items/NewWeaponItem.asset");
        AssetDatabase.SaveAssets();
    }
}
#endif
