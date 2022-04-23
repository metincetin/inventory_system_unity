using UnityEngine;

namespace InventorySystem.Core
{
    public abstract class BaseItem : ScriptableObject
    {
        [SerializeField]
        private string m_id;
        public string ID
        {
            get => m_id;
        }
        public abstract string Name { get; }
        public int MaxStackAmount;
        public bool Stackable => MaxStackAmount > 1;
    }
}
