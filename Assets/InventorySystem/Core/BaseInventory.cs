using System;
using UnityEngine;

namespace InventorySystem.Core
{
    public abstract class BaseInventory : MonoBehaviour
    {
        public abstract void AddItem(BaseItem item);
        public abstract void RemoveItem(BaseItem item);
        public event Action<ItemStack> ItemStackCreated;
        public event Action<ItemStack> ItemStackRemoved;
        public event Action<ItemStack, int, int> ItemStackCountChanged;

        public event Action<BaseItem> ItemAdded;
        public event Action<BaseItem> ItemRemoved;
        public event Action InventoryChanged;

        public abstract ItemStack GetItemStack(string id);
        public abstract ItemStack GetItemStack(BaseItem item);
        public abstract bool CanAddItem(BaseItem item);

        public abstract void MoveItem(ItemStack from, ItemStack to);

        public bool HasItem(BaseItem item) => GetItemStack(item) != null;
        public bool HasItem(string id) => GetItemStack(id) != null;

        protected void OnItemAdded(BaseItem item)
        {
            ItemAdded?.Invoke(item);
        }

        protected void OnItemRemoved(BaseItem item)
        {
            ItemRemoved?.Invoke(item);
        }

        protected void OnInventoryChanged()
        {
            InventoryChanged?.Invoke();
        }

        protected void OnStackCreated(ItemStack stack)
        {
            ItemStackCreated?.Invoke(stack);
        }
        
        
        protected void OnStackRemoved(ItemStack stack)
        {
            ItemStackRemoved?.Invoke(stack);
        }

        protected void OnItemStackCountChanged(ItemStack stack, int current, int previous)
        {
            ItemStackCountChanged?.Invoke(stack, current, previous);
        }
    }
}
