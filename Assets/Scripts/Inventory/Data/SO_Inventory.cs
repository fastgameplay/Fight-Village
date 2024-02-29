namespace FightVillage.Inventory.Data
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "SO_Inventory", menuName = "Data/Inventory")]
    public class SO_Inventory : ScriptableObject
    {
        [SerializeField] private List<InventoryItem> _inventoryItems;
        [field: SerializeField] public int Size { get; private set; } = 30;

        public void Initialize()
        {
            _inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                _inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public void AddItemTEST(SO_Item item, int quantity)
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if(_inventoryItems[i].IsEmpty){
                    _inventoryItems[i] = new InventoryItem(item, quantity);
                }
            }
        }
        public Dictionary<int,InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int,InventoryItem> output = new Dictionary<int,InventoryItem>();
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if(_inventoryItems[i].IsEmpty) continue;
                output.Add(i, _inventoryItems[i]);
            }
            return output;
        }
    }
}