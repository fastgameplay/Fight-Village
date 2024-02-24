namespace FightVillage.UI
{
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    public class UIInventoryWindow : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _inventoryObjectPrefab;
        [SerializeField] private UIInventoryPopUp _inventoryPopUp;
        [SerializeField] private Transform _contextObject;

        [Space(20)]
        [Header("Temporary")]
        [SerializeField] Sprite tempSprite1;
        [SerializeField] int tempQuantity1;
        [SerializeField] Sprite tempSprite2;
        [SerializeField] int tempQuantity2;

        [SerializeField] int _inventorySize;
        private List<UIInventoryItem> _listOfObjects = new List<UIInventoryItem>();



        private void Start() {
            InitializeInventory(_inventorySize);
            _listOfObjects[1].SetData(tempSprite1,tempQuantity1);
            _listOfObjects[5].SetData(tempSprite2,tempQuantity2);
        }
        public void InitializeInventory(int size){
            for (int i = 0; i < size; i++){
                UIInventoryItem currentObject = Instantiate(_inventoryObjectPrefab, _contextObject);
                currentObject.Reset();
                currentObject.name = $"Item 0{i}";
                currentObject.OnItemClicked += HandlePopUp;
                currentObject.OnRightMouseBtnClicked += HandleUse;
                currentObject.OnItemBeginDrag += HandleItemBeginDrag;
                currentObject.OnItemEndDrag += HandleItemEndDrag;
                currentObject.OnItemDropedOn += HandleItemSwap;
                _listOfObjects.Add(currentObject);
            }
        }

        private void HandlePopUp(UIInventoryItem item)
        {   
            _inventoryPopUp.Show(tempSprite1, "Temporary Name");
            Debug.Log($"Clicked Left Btn On {name}");
        }
        private void HandleUse(UIInventoryItem item)
        {
            //Equip if Equipable, Buy if Buyable, use if usable
            Debug.Log($"Use Btn On {name}");
            
        }
        private void HandleItemBeginDrag(UIInventoryItem item)
        {
            //Swap Items
            Debug.Log($"Drag Begin  On {name}");
        }
        private void HandleItemEndDrag(UIInventoryItem item)
        {
            Debug.Log($"Drag End On {name}");
        }
        private void HandleItemSwap(UIInventoryItem item)
        {
            Debug.Log($"Item Droped On{name}");
        }
    }
}