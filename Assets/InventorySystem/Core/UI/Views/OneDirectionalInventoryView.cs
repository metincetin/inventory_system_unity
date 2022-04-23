using System;
using InventorySystem.Core.Inventories;
using UnityEngine;

namespace InventorySystem.Core.UI.Views
{
    public class OneDirectionalInventoryView : MonoBehaviour
    {
        public OneDimensionalInventory Inventory;

        private void OnEnable()
        {
            Inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            Inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void OnInventoryChanged()
        {
            
        }
    }
}
