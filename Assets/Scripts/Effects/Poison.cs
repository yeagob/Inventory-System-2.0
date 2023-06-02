using UnityEngine;
using System;

namespace Prueba.Effects
{
	/// <summary>  
	/// Poison describing its purpose.
	/// </summary>
	public class Poison : Effect
	{

		#region Properties
		private GameManager Manager => GameManager.Instance;

		#endregion Properties

		#region Public Methods

		public override void AppyEffect()
		{
			Manager.UI.Popup.ShowModalMode("You feel bad...", 2);

		}
		#endregion
	}
}