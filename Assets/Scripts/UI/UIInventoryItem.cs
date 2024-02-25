namespace FightVillage.UI
{
    using UnityEngine.UI;
    using UnityEngine;
    using System;
    using TMPro;
    using UnityEngine.EventSystems;

    public class UIInventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IDropHandler
    {
        private bool backGroundImageState
        {
            get => _backGroundImage.enabled;
            set => _backGroundImage.enabled = value;
        }
        private bool counterTextState
        {
            get => _counterText.gameObject.activeSelf;
            set => _counterText.gameObject.SetActive(value);
        }
        [SerializeField] private Image _backGroundImage;         
        [SerializeField] private Image _itemImage;       
        [SerializeField] private TextMeshProUGUI _counterText;
        public event Action<UIInventoryItem> OnItemClicked, OnRightMouseBtnClicked, OnItemDropedOn, OnItemBeginDrag, OnItemEndDrag;

        bool _empty = true;

        public void Reset()
        {
            _itemImage.gameObject.SetActive(false);
            _empty = true;
        }
        public void SetData(Sprite sprite, int quantity)
        {
            _itemImage.gameObject.SetActive(true);
            counterTextState = quantity > 1;
            
            _counterText.text = quantity.ToString();
            _itemImage.sprite = sprite;
            _empty = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(_empty) 
                return;
            OnItemBeginDrag?.Invoke(this);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }
        public void OnDrag(PointerEventData eventData) {}

        public void OnPointerClick(PointerEventData eventData)
        {
            //TODO: Implement Mobile Input
            if(eventData.button == PointerEventData.InputButton.Right)
            {
                
                OnRightMouseBtnClicked?.Invoke(this);
            }
            else if(eventData.button == PointerEventData.InputButton.Left)
            {
                OnItemClicked?.Invoke(this);
            }
        }
        public void OnDrop(PointerEventData eventData)
        {
            OnItemDropedOn?.Invoke(this);
        }
    }   
    
}