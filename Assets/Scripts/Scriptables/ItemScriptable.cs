using UnityEngine;

namespace Prueba.Inventory
{
	using Prueba.Effects;
	using System.Collections.Generic;
	using UnityEngine;

    public abstract class ItemScriptable : ScriptableObject
    {
        public string itemName = "";
        public Sprite itemImage;
        public float itemWeight = 0;
    }

    // Para Basura
    public class TrashItemScriptable : ItemScriptable
    {
        // Solo los campos de la clase base
    }

}
