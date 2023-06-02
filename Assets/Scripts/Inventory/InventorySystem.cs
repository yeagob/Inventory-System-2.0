using UnityEngine;
using System;
using System.Collections.Generic;

namespace Prueba.Inventory
{
    public enum ItemType
	{
        None = -1,
        Weapon = 0,
        Resource = 1,
        Consumable = 2,
        Trash = 3
	}

    /// <summary>  
    /// InventorySystem implements factory desing. Create and control IItems
    /// </summary>
    public class InventorySystem 
    {
        #region Fields
        private List<Item> _itemsInventory;
        [SerializeField] private float _maxWeight = 100;
        private float _currenWeight = 0;
        #endregion Fields

        #region Properties
        [field: SerializeField] public List<ItemScriptable> AvailableItems = new List<ItemScriptable>();
        private GameManager Manager => GameManager.Instance;
       
        #endregion Properties

        #region Events / Delegates
        public event Action<Item> OnItemUsed;		

		public event Action<Item> OnItemDeleted;
       
		#endregion Events / Delegates

		#region Public Methods

		public void AddItem(ItemScriptable newItemScriptable)
		{
            Item newItem = null;

            //Add Trash
            if (newItemScriptable is TrashItemScriptable trash)
                newItem = new Item(trash.itemName, trash.itemImage, trash.itemWeight);
            
            //Add Weapon
            if (newItemScriptable is WeaponItemScriptable weapon)
                newItem = new Weapon(weapon.itemName, weapon.itemImage, weapon.itemWeight, weapon.dps, weapon.price, weapon.weaponRequirements);

            //Add Resource
            if (newItemScriptable is ResourceItemScriptable resource)
                newItem = new Resource(resource.itemName, resource.itemImage, resource.itemWeight, resource.price, resource.durability);

            //Add Consumable
            if (newItemScriptable is ConsumableItemScriptable consumable)
                newItem = new Consumable(consumable.itemName, consumable.itemImage, consumable.itemWeight, consumable.durability, consumable.effects);

            if (CanCarry(newItem.Weight))
			{
                _currenWeight += newItem.Weight;
                _itemsInventory.Add(newItem);
                Manager.UI.CreateItemUI(newItem);
			}
        }

		internal void CreateTrash(float weight)
		{
			foreach(ItemScriptable item in AvailableItems)
            { 
                if (item is TrashItemScriptable)
				{
                    item.itemWeight = weight;
                    AddItem(item);
				}
            }
		}

		public void UseItem (Item item)
		{
            OnItemUsed?.Invoke(item);
		}

        internal void ItemUpdated(Item resource)
        {
            //Refresh current selected Item
            Manager.UI.Update();
        }

        public void DeleteItem(Item item)
        {
            _currenWeight -= item.Weight;
            _itemsInventory.Remove(item);
            OnItemDeleted?.Invoke(item);
            Manager.UI.Update();
        }
        public Item ItemExist(string itemName)
		{
            return _itemsInventory.Find(item => item.Name == itemName);
        }

		public float GetCurrentWeight()
		{
            return _currenWeight;
		}

		public void WeakItems(float durabilityLoss)
        {
            foreach (Item item in _itemsInventory)
                if (item is IDurable durableItem)
                    durableItem.Weaken(durabilityLoss);
        }
        #endregion

        #region Private Methods

        private bool CanCarry(float weight)
        {
            return _currenWeight + weight <= _maxWeight;
        }
        #endregion

    }
}