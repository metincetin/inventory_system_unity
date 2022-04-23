using InventorySystem.Core.Interfaces;
using UnityEditor.UIElements;
using UnityEngine;

namespace InventorySystem.Core
{
    public abstract class ItemUser: MonoBehaviour
    {
        public virtual void Use(IUsable item)
        {
            item.OnUsed(this);
            OnUsed(item);
        }

        protected abstract void OnUsed(IUsable usable);
    }
}
