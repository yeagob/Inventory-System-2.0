using UnityEngine;
using Prueba.Inventory;
using Prueba.UI;

namespace Prueba
{
    /// <summary>  
    /// GameManager implements Singleton desing. Have references to UIController(UI) & Inventory System(Inventory=
    /// </summary>
    public class GameManager : MonoBehaviour
    {
		#region Fields
		private int _timeLapse = 0;
		#endregion

		#region Properties
		//Mini singleton
		public static GameManager Instance;
		[field: SerializeField] public UIController UI;
		[field: SerializeField] public InventorySystem Inventory;
		#endregion Properties

		#region Events / Delegates

		#endregion Events / Delegates

		#region Unity Callbacks
		private void Awake()
		{
			//Mini Singleton
			if (Instance != null)
			{
				Destroy(gameObject);
				return;
			}

			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;

			//Creates Inventrory System / Items Factory
			Inventory = new InventorySystem();

		}
		#endregion Unity Callbacks

		#region Public Methods
		public void TimeLapse()
		{
			Inventory.WeakItems(1);
			UI.Popup.ShowModalMode("Day " + (++_timeLapse), 1);
		}
		#endregion
	}
}