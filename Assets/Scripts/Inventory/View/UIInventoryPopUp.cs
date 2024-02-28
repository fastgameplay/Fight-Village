namespace FightVillage.Inventory.UI
{
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    public class UIInventoryPopUp : MonoBehaviour
    {
        public Action OnItemActionRequested, OnItemDeleteRequested;
        

        [Header("Reference")]
        [SerializeField] TextMeshProUGUI _actionButtonText;
        [SerializeField] TextMeshProUGUI _title;
        [SerializeField] UIInventoryItem _item;

        [SerializeField] PopUpReference _weightStats;
        [SerializeField] PopUpReference _secondaryStats;


        public void Show(Sprite itemImage, int itemQuantity, string itemName,  string actionBtnText)
        {
            _item.SetData(itemImage, itemQuantity);
            _actionButtonText.text = actionBtnText;
            _title.text = itemName;
            gameObject.SetActive(true);
        }

        public void OnActionButton()
        {
            OnItemActionRequested?.Invoke();
            Reset();
        }
        public void OnDeleteButton()
        {
            OnItemDeleteRequested?.Invoke();
            Reset();
        }

        public void Reset()
        {
            gameObject.SetActive(false);
        }
    }

    [Serializable]
    public struct PopUpReference
    {
        [field: SerializeField] public TextMeshProUGUI Counter {get; private set;}
        [field: SerializeField] public Image Image {get; private set;}
    }

}