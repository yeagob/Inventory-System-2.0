using UnityEngine;
using System;

namespace Prueba.Effects
{
    /// <summary>  
    /// Heal describing its purpose.
    /// </summary>
    public class Heal : Effect
	{
        
        #region Properties
        private GameManager Manager => GameManager.Instance;

		#endregion Properties

		#region Public Methods
		public override void AppyEffect()
		{
			Manager.UI.Popup.ShowModalMode("You feel better!", 2);
		}


		#endregion

	}
}