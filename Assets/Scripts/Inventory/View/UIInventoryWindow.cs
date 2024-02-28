namespace FightVillage.Inventory.UI

{
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    public class UIInventoryWindow : MonoBehaviour
    {
        
        [SerializeField] private UIInventoryItem _inventoryObjectPrefab;
        [SerializeField] private Transform _contextObject;
        [SerializeField] private MouseFollower _mouseFollower;

        private List<UIInventoryItem> _listOfObjects = new List<UIInventoryItem>();
        public event Action<int> OnPopUpRequested, OnItemActionRequested, OnItemDeleteRequested, OnStartDragging;
        public event Action<int,int> OnSwapItems;
        private int _currentlyDraggedItemIndex = -1;

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
            ResetDraggedItem();
        }
        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if(_listOfObjects.Count > itemIndex)
            {
                _listOfObjects[itemIndex].SetData(itemImage, itemQuantity);
            }
        }
        private void HandlePopUp(UIInventoryItem item)
        {   
            int index = _listOfObjects.IndexOf(item);
            if( index == -1) return;
            OnPopUpRequested?.Invoke(index);
        }
        private void HandleUse(UIInventoryItem item)
        {
            int index = _listOfObjects.IndexOf(item);
            if( index == -1) return;
            OnItemActionRequested?.Invoke(index);
        }
        private void HandleItemBeginDrag(UIInventoryItem item)
        {
            int index = _listOfObjects.IndexOf(item);
            if( index == -1) return;
            _currentlyDraggedItemIndex = index;

            OnStartDragging?.Invoke(index);
        }
        private void HandleItemEndDrag(UIInventoryItem item)
        {
            ResetDraggedItem();
        }
        private void HandleItemSwap(UIInventoryItem item)
        {
            int index = _listOfObjects.IndexOf(item);
            if(index == -1) 
            {
                return;
            }
            OnSwapItems?.Invoke(_currentlyDraggedItemIndex,index);
        }
        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            _mouseFollower.Toggle(true);
            _mouseFollower.SetData(sprite, quantity);

        }
        private void ResetDraggedItem()
        {
            _mouseFollower.Toggle(false);
            _currentlyDraggedItemIndex = -1;
        }
    }
}