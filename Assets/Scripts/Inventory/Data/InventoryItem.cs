namespace FightVillage.Inventory.Data
{
    public struct InventoryItem
    {
        public int Quantity { get; private set; }
        public SO_Item Item { get; private set; }
        public bool IsEmpty =>  Item == null;

        public InventoryItem(SO_Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public InventoryItem ChangeQuantity(int quantity) => new InventoryItem(Item, quantity);
        public static InventoryItem GetEmptyItem() => new InventoryItem(null, 0);
    }

}
