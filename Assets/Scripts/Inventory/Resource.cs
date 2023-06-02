using UnityEngine;
using System;

namespace Prueba.Inventory
{
    /// <summary>  
    /// Resource describing its purpose.
    /// </summary>
    public class Resource : Item, IDurable, ISaleable
    {
		public float Price { get ; set ; }
		public float Durability { get; set; }
		#region Fields

		#endregion Fields

		#region Properties
		private GameManager Manager => GameManager.Instance;
		#endregion Properties

		#region Public Methods
		public Resource(string name, Sprite image, float weight, float price, float durability) : base(name, image, weight) // Call to the base constructor.
		{
			Price = price;
			Durability = durability;
		}
		public void SellItem()
		{
			Manager.Inventory.DeleteItem(this);
			Manager.UI.Popup.ShowModalMode("You win " + Price + " gold coins.");
		}

		public void Weaken(float durabilityReduction)
		{
			Durability -= durabilityReduction;
			Price -= Price / 2;
			if (Durability <= 0)
			{
				Manager.Inventory.DeleteItem(this);
				Manager.Inventory.CreateTrash(Weight);
			}
			else
				Manager.Inventory.ItemUpdated(this);
		}
		#endregion

		#region Private Methods

		#endregion
	}
}