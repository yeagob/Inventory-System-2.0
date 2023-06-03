using UnityEngine;
using System;
using Prueba.Inventory;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace Prueba.UI
{
    /// <summary>  
    /// UIController describing its purpose.
    /// </summary>
    public class UIController : MonoBehaviour
    {
        #region Fields
        //Available Items (Scriptable Object refs) (Todo: move to InventorySystem)
        [SerializeField] private List<ItemScriptable> _availableItems;

        //Prefabs on scene, to clone them. They are placed on the grid, then them paret its the parent of the Prefab clones.
        [SerializeField] private ItemUI _itemUIPrefab;
        [SerializeField] private Button _buttonAddItemPrefab;

        //Slider Weight
        [SerializeField] private Slider _weightSlider;
        
        //Created Items
        private List<ItemUI> _createdUIItems = new List<ItemUI>();

        //Item Selected
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
		private void Start()
		{
            //Create and Initialize Add Item Buttons
            for (int i = 0; i < _availableItems.Count; i++)
                InitializeAddButton(_availableItems[i]);

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

		internal void UpdateInfo()
		{
            OnItemSelected?.Invoke(_itemSelected.ItemObject);
        }

        #endregion

        #region Private Methods
        private void InitializeAddButton(ItemScriptable itemScriptable)
        {
            //We dont want trash like u!
            if (itemScriptable is TrashItemScriptable)
                return;

            //Add Button Creation
            Button newAddButton = Instantiate(_buttonAddItemPrefab, _buttonAddItemPrefab.transform.parent);

            //On Click add item to panel
            newAddButton.onClick.AddListener(() => Manager.Inventory.AddItem(itemScriptable));

            //Change text
            newAddButton.GetComponentInChildren<TextMeshProUGUI>().text = "Add " + itemScriptable.itemName;

            //Original prefab it is disabled
            newAddButton.gameObject.SetActive(true);
        }

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

        #region Public Methods
        public void CreateTrash(float weight)
        {
            foreach (ItemScriptable item in _availableItems)
            {
                if (item is TrashItemScriptable)
                {
                    item.itemWeight = weight;
                    Manager.Inventory.AddItem(item);
                }
            }
        }
        #endregion
    }
}