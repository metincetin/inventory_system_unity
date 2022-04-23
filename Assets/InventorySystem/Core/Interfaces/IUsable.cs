using UnityEngine;

namespace InventorySystem.Core.Interfaces
{
    public interface IUsable
    {
        public void OnUsed(ItemUser user);
    }
}
