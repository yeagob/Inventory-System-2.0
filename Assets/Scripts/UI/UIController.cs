using UnityEngine;
using System;
using Prueba.Inventory;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Prueba.UI
{
    /// <summary>  
    /// UIController describing its purpose.
    /// </summary>
    public class UIController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private ItemUI _itemUIPrefab;
        [SerializeField] private Slider _weightSlider;
        private List<ItemUI> _createdUIItems = new List<ItemUI>();
        private ItemUI _itemSelected;
        #endregion Fields
    
        #region Properties
        [field: SerializeField] public MultifunctionalPanelUI Popup { get; set; }
        [field: SerializeField] public Button buttonAddItemPrefab { get; set; }
        private GameManager Manager => GameManager.Instance;

        #endregion Properties

        #region Events / Delegates
        public event Action<Item> OnItemSelected;
		#endregion Events / Delegates

		#region Unity Callbacks
		private void Awake()
		{
            Manager.Inventory.OnItemDeleted += ItemDeleted;
		}

		#endregion Unity Callbacks

		#region Public Methods

        public ItemUI CreateItemUI(Item item)
		{
            ItemUI newItem = Instantiate(_itemUIPrefab, _itemUIPrefab.transform.parent);
            newItem.Initialize(item);
            _createdUIItems.Add(newItem);
            ItemSelected(item, true);
            return newItem;
        }

		public void ItemSelected(Item item, bool selected)
        {
            if (selected)
			{
                _itemSelected = _createdUIItems.Find(uiItem => uiItem.ItemObject == item);
                _weightSlider.value = Manager.Inventory.GetCurrentWeight();
                OnItemSelected?.Invoke(item);
			}
        }

		internal void Update()
		{
            OnItemSelected?.Invoke(_itemSelected.ItemObject);
        }

        #endregion

        #region Private Methods
        private void ItemDeleted(Item item)
        {
            ItemUI itemUI = _createdUIItems.Find(uiItem => uiItem.ItemObject == item);
            if (itemUI != null)
            {
                Destroy(itemUI.gameObject);
                _createdUIItems.Remove(itemUI);
                _weightSlider.value = Manager.Inventory.GetCurrentWeight();
            }
        }
        #endregion
    }
}