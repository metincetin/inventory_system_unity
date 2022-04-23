using UnityEngine;

namespace InventorySystem.Core
{
    public class ItemStack
    {
        public BaseItem Item;
        private int m_stackAmount;
        public int StackAmount
        {
            get => m_stackAmount;
            set
            {
                var clampedValue = Mathf.Clamp(value, 1, Item.MaxStackAmount);
                m_stackAmount = value;
            }
        }

        public Vector2Int Position { get; set; }
        
        public ItemStack(BaseItem item)
        {
            Item = item;
        }
    }
}