namespace FightVillage.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    public class UIInventoryObject : MonoBehaviour
    {
        public bool BackGroundImageState{
            get => _backGroundImage.enabled;
            set => _backGroundImage.enabled = value;
        }
        [SerializeField] private Image _backGroundImage;       
        [SerializeField] private Image _itemImage;       
        [SerializeField] private TextMeshProUGUI _counterText;       
    }
    
}