using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Core.Inventories
{
    public class OneDimensionalInventory : BaseInventory
    {
        [Tooltip("Determines how many item stack can be added to this inventory. -1 for limitless.")]
        public int ItemLimit = 10;

        private List<ItemStack> m_itemStacks = new List<ItemStack>();
        
        public override void AddItem(BaseItem item)
        {
            if (!CanAddItem(item)) return;
            
            var existingStack = GetItemStack(item);
            if (existingStack == null || existingStack.Item.MaxStackAmount - existingStack.StackAmount <= 0)
            {
                var stack = new ItemStack(item);
                stack.StackAmount = 1;
                m_itemStacks.Add(stack);
                OnStackCreated(stack);
            }
            else
            {
                var previousCount = existingStack.StackAmount;
                existingStack.StackAmount++;
                OnItemStackCountChanged(existingStack, existingStack.StackAmount, previousCount);
            }
            
            OnItemAdded(item);
            OnInventoryChanged();
        }

        public override void RemoveItem(BaseItem item)
        {
            var stack = GetItemStack(item);
            if (stack != null)
            {
                if (stack.StackAmount > 1)
                {
                    var previousCount = stack.StackAmount;
                    stack.StackAmount--;
                    OnItemStackCountChanged(stack, stack.StackAmount, previousCount);
                }
                else
                {
                    m_itemStacks.Remove(stack);
                    OnStackRemoved(stack);
                }
                
                OnItemRemoved(item);
                OnInventoryChanged();
            }
        }

        public override ItemStack GetItemStack(string id)
        {
            foreach (var stack in m_itemStacks)
            {
                if (stack.Item.ID == id) return stack;
            }

            return null;
        }

        public override ItemStack GetItemStack(BaseItem item)
        {
            foreach (var stack in m_itemStacks)
            {
                if (stack.Item == item) return stack;
            }

            return null;
        }

        public override bool CanAddItem(BaseItem item)
        {
            if (ItemLimit != -1 && m_itemStacks.Count >= ItemLimit) return false;
            return true;
        }

        public override void MoveItem(ItemStack from, ItemStack to)
        {
            throw new System.NotImplementedException("OneDirectionalInventory doesn't support moving items");
        }
    }
}
