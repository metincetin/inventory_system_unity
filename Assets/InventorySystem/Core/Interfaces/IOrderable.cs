using System;

namespace InventorySystem.Core.Interfaces
{
    public interface IOrderable
    {
        public void Order(Action<BaseItem, int> predicate);
    }
}