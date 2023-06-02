using UnityEngine;
using System;

namespace Prueba.Inventory
{
    /// <summary>  
    /// IItem base class for items definition
    /// </summary>
    [Serializable]
    public class Item : ScriptableObject
    {
        #region Properties
        public string Name { get; private set; }
        public Sprite Sprite { get; private set; }
        public float Weight { get; private set; }

        #endregion Properties


        #region Public Methods

        //Constructor
        public Item(string name, Sprite image, float weight)
		{
            Name = name;
            Sprite = image;
            Weight = weight;
		}
        #endregion


    }
}