using UnityEngine;
using Prueba.Inventory;
using Prueba.UI;

namespace Prueba
{
    /// <summary>  
    /// GameManager implements Singleton desing 
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Fields
        
        #endregion Fields
    
        #region Properties
        public static GameManager Instance { get; private set; }
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
		}
		#endregion
	}
}