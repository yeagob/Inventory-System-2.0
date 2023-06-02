using UnityEngine;
using System;

namespace Prueba.Inventory
{

    /// <summary>  
    /// IUsable Interface for durable items
    /// </summary>
    public interface IDurable
    {
        public float Durability { get; set; }
        public void Weaken(float durabilityReduction);

    }
}