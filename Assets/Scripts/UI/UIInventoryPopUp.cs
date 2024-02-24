namespace FightVillage.UI
{
    using System;
    using System.Linq;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    public class UIInventoryPopUp : MonoBehaviour
    {
        [SerializeField] GameObject _popUpWindow;
        [SerializeField] TextMeshProUGUI _title;
        [SerializeField] Image _itemImage; 

        public void Show(Sprite itemImage, string itemName)
        {
            _popUpWindow.SetActive(true);
            _itemImage.sprite = itemImage;
            _title.text = itemName;
        }
        public void Reset()
        {
            _popUpWindow.SetActive(false);
        }
    }

}