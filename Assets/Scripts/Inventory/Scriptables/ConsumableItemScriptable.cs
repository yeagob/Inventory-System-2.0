using Prueba.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace Prueba.Inventory
{
    public class ConsumableItemScriptable : ItemScriptable
    {
        public float durability;
        public List<EffectScriptable> effects = new List<EffectScriptable>();
    }
}