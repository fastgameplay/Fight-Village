namespace FightVillage.Inventory.UI
{
    using UnityEngine;
    public class MouseFollower : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] UIInventoryItem _item;

        private void Awake()
        {
            _canvas = transform.root.GetComponent<Canvas>();
            _item = GetComponentInChildren<UIInventoryItem>();
        }
        public void SetData(Sprite sprite, int quantity)
        {
            _item.SetData(sprite,quantity);
        }
        private void Update()
        {
            //TODO: Update to unity new input system;
            UpdatePosition();
        }
        private void UpdatePosition()
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)_canvas.transform,
                Input.mousePosition,
                _canvas.worldCamera,
                out position
                    );
            transform.position = _canvas.transform.TransformPoint(position);
        }
        public void Toggle(bool state)
        {
            UpdatePosition();
            gameObject.SetActive(state);
        }
    }
}