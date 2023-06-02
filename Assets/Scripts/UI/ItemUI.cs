using UnityEngine;
using System;
using UnityEngine.UI;
using Prueba.Inventory;

namespace Prueba
{
    /// <summary>  
    /// ItemUI UI element of each item.
    /// </summary>
    public class ItemUI : MonoBehaviour
    {
		#region Fields
		[SerializeField] private Image _itemImage;
		private Toggle _myToggle;
        #endregion Fields

        #region Properties
		public Item ItemObject { get; private set; }
        private GameManager Manager => GameManager.Instance;

		#endregion Properties

		#region Events / Delegates
		public event Action<Item> OnItemSelected;
		#endregion Events / Delegates

		#region Unity Callbacks
		private void Awake()
		{
			_myToggle = GetComponent<Toggle>();
			_myToggle.onValueChanged.AddListener((state) => Manager.UI.ItemSelected(ItemObject, state));
		}
		#endregion Unity Callbacks

		#region Public Methods
		public void Initialize (Item item)
		{
			gameObject.SetActive(true);
			ItemObject = item;
			_itemImage.sprite = item.Sprite;
		}
		#endregion

	}
}