using UnityEngine;
using System;

namespace Prueba.Inventory

{
    /// <summary>  
    /// IUsable Interface for saleable items
    /// </summary>
    public interface ISaleable
    {
        public float Price { get; set; }

        public void SellItem();
    }
}