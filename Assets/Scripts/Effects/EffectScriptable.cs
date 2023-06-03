using System;
using UnityEngine;

namespace Prueba.Effects
{
    /// <summary>  
    /// Base Class for Effects
    /// </summary>
    [Serializable]
    public class EffectScriptable: ScriptableObject
    {
        #region Properties
        [field: SerializeField] public string effectMessage { private get; set; }
        private GameManager Manager => GameManager.Instance;

        #endregion Properties

        #region Public Methods
        public void AppyEffect()
        {
            Manager.UI.Popup.ShowModalMode(effectMessage, 2);
        }


        #endregion
    }
}