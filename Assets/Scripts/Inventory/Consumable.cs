using UnityEngine;
using System;
using Prueba.Effects;
using System.Collections.Generic;

namespace Prueba.Inventory
{
    /// <summary>  
    /// Consumable describing its purpose.
    /// </summary>
    public class Consumable : Item, IUsable, IDurable
    {
		#region Fields

		List<EffectScriptable> _effects;

		#endregion Fields

		#region Properties
		private GameManager Manager => GameManager.Instance;

		public float Durability { get; set; }


		#endregion Properties

		#region Events / Delegates

		#endregion Events / Delegates

		#region Unity Callbacks

		#endregion Unity Callbacks

		#region Public Methods
		public Consumable(string name, Sprite image, float weight,  float durability, List<EffectScriptable> effects) : base(name, image, weight) // Call to the base constructor.
		{
			Durability = durability;
			_effects = effects;
		}

		public void UseItem()
		{
			Manager.Inventory.DeleteItem(this);
			for (int i = 0; i < _effects.Count; i++)
				_effects[i].AppyEffect();
		}

		public void Weaken(float durabilityReduction)
		{
			Durability -= durabilityReduction;
			if (Durability <= 0)
			{
				Manager.Inventory.DeleteItem(this);
				Manager.UI.CreateTrash(Weight);
			}
			else
				Manager.Inventory.ItemUpdated(this);
		}
		#endregion

		#region Private Methods

		#endregion
	}
}