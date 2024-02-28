using FightVillage.Inventory.UI;
using Unity.VisualScripting;
using UnityEngine;
namespace FightVillage.Inventory.Controller
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] UIInventoryWindow _uiInventoryWindow;
        [SerializeField] UIInventoryPopUp _uiInventoryPopUp;
        [SerializeField] int _inventorySlotAmount;
        [SerializeField] Sprite _image;
        [SerializeField] Sprite _image2;
        private void Start() {
            _uiInventoryWindow.InitializeInventory(_inventorySlotAmount);
            _uiInventoryWindow.UpdateData(0,_image, 10);
            _uiInventoryWindow.UpdateData(5,_image2, 25);
            _uiInventoryPopUp.Show(_image,30,"9.00mm ammo", "Use");
        }
    }
}