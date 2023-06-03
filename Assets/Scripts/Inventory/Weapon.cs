using UnityEngine;
using System;
using System.Collections.Generic;

namespace Prueba.Inventory
{
    /// <summary>  
    /// Weapon describing its purpose.
    /// </summary>
    public class Weapon : Item, IUsable, ISaleable
    {
        #region Fields

        private string _weaponRequeriments;
        
        #endregion Fields
    
        #region Properties
        [field: SerializeField] public float Dps { get; }
        private GameManager Manager => GameManager.Instance;

		public float Price { get ; set ; }

		#endregion Properties
		
		#region Public Methods
		public Weapon(string name, Sprite image, float weight, float dps, float price, ResourceItemScriptable weaponRequeriments = null) : base(name, image, weight) // Call to the base constructor.
        {
            Dps = dps;
			Price = price;
            _weaponRequeriments = weaponRequeriments?.itemName;
        }

		public void UseItem()
		{
			if (_weaponRequeriments != null)
			{
				Item item = Manager.Inventory.ItemExist(_weaponRequeriments);
				if (item != null)
				{
					Manager.Inventory.DeleteItem(item);
					Manager.UI.Popup.ShowModalMode("You attack dps: " + Dps, 1);
				}
				else
					Manager.UI.Popup.ShowModalMode("Do you need " + _weaponRequeriments + " to use " + Name);
				return;
			}
			Manager.UI.Popup.ShowModalMode("You attack dps: " + Dps, 1);
		}

		public void SellItem()
		{
			Manager.Inventory.DeleteItem(this);
			Manager.UI.Popup.ShowModalMode("You win " + Price + " gold coins.");
		}

		#endregion

		#region Private Methods

		#endregion
	}
}