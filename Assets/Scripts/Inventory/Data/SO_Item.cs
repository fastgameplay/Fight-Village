namespace FightVillage.Inventory.Data
{
    using FightVillage.UI;
    using UnityEngine;
    [CreateAssetMenu(fileName = "SO_Item", menuName = "Data/Item")]
    public class SO_Item : ScriptableObject {
        public int ID => GetInstanceID();
        [field: SerializeField] public ItemType Type { get; set; }
        [field: SerializeField] public bool IsStackable { get; set; }
        [field: SerializeField] public int MaxStackSize { get; set; } = 1;
        [field: SerializeField] public float Weight { get; set; }
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public Sprite Image { get; set; }

    }

}