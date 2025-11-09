using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour//, IPointerClickHandler
{
    [SerializeField] private Sprite _itemIcon;

    [SerializeField] private GameObject _portaIcon;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private GameObject _containerCount;
    [SerializeField] private TextMeshProUGUI _countItem;

    InventoryItem _item;
    
    //Button _button;

    private void Awake() {
        //_button = GetComponent<Button>();
    }

    public void Set(InventoryItem item) {
        _item = item;
        _itemName.text = item.data.ItemName;
        _portaIcon.GetComponent<Image>().sprite = item.data.ItemIcon;
        //_button.image.sprite = item.data.ItemIcon;

        if(item.countItem > 1) {
            _containerCount.SetActive(true);
            _countItem.enabled = true;
            _countItem.text = item.countItem.ToString();
        } else {
            _containerCount.SetActive(false);
            _countItem.enabled = false;
        }

    }

    //public void OnPointerClick(PointerEventData eventData) {

    //    if(eventData.button == PointerEventData.InputButton.Left) {
    //        Debug.Log("Left Click");
    //        itemActionsManager.Instance.UseSelectedItem(_item);
    //    }else if(eventData.button == PointerEventData.InputButton.Right) {
    //        Debug.Log("Right Click");
    //        itemActionsManager.Instance.DropSelectedItem(_item);
    //    }

    //}
}
