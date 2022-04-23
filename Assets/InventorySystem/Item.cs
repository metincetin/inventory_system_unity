using InventorySystem.Core;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item : BaseItem
    {
        [SerializeField]
        private string m_name;
        public override string Name => m_name;
    }
}
