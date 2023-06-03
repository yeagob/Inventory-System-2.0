using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Prueba.Inventory;

namespace Prueba.UI
{
    /// <summary>  
    /// ItemPanel Shows Item info on ui text and control click button actions
    /// </summary>
    public class ItemPanel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Item _currentItem;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _weigthText;
        [SerializeField] private TextMeshProUGUI _dpsText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _durabilityText;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _sellButton;
        #endregion Fields

        #region Properties
        private GameManager Manager => GameManager.Instance;
        #endregion Properties

		#region Unity Callbacks
		private void Start()
		{
            //Use / Delete / Sell Actions
            _useButton.onClick.AddListener(() => (_currentItem as IUsable).UseItem());			
            _sellButton.onClick.AddListener(() => (_currentItem as ISaleable).SellItem());
            _deleteButton.onClick.AddListener(() => Manager.Inventory.DeleteItem(_currentItem));

            //Listen When an item it is selected/deleted
            Manager.UI.OnItemSelected += UpdateData;
            Manager.Inventory.OnItemDeleted += ItemDeleted;

            ShowElelemts(false);
        }

		#endregion Unity Callbacks

		#region Private Methods

		private void ItemDeleted(Item item)
		{
			if (item == _currentItem)
                UpdateData(_currentItem);
		}
		private void UpdateData(Item item)
		{
            _currentItem = item;

            if (item == null)
			{
                ShowElelemts(false);
                return;
			}
            ShowElelemts(true);

            //Update Texts
            _nameText.text = "Name: \t" + item.Name;
            _weigthText.text = "Weight: \t" + item.Weight;

            //Especific Elements
            if (item is Weapon weapon)
                _dpsText.text = "DPS: \t" + weapon.Dps;

            if (item is ISaleable itemSaleable)		
                _priceText.text = "Price: \t" + itemSaleable.Price;                           

            if (item is IDurable itemDurable)
                _durabilityText.text = "Durability: \t" + itemDurable.Durability;

            //Update objects State
            _dpsText.gameObject.SetActive(item is Weapon);
            _priceText.gameObject.SetActive(item is ISaleable);
            _sellButton.gameObject.SetActive(item is ISaleable);
            _durabilityText.gameObject.SetActive(item is IDurable);
            _useButton.gameObject.SetActive(item is IUsable);

        }

        #endregion Public Methods

        #region Private Methods
        private void ShowElelemts(bool state)
		{
            _nameText.gameObject.SetActive(state);
            _weigthText.gameObject.SetActive(state);
            _dpsText.gameObject.SetActive(state);
            _priceText.gameObject.SetActive(state);
            _durabilityText.gameObject.SetActive(state);
            _dpsText.gameObject.SetActive(state);
            _priceText.gameObject.SetActive(state);
            _durabilityText.gameObject.SetActive(state);
            _useButton.gameObject.SetActive(state);
            _sellButton.gameObject.SetActive(state);
        }

        #endregion

	}
}