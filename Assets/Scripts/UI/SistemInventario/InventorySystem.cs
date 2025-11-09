using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private static InventorySystem instance;
    public static InventorySystem Instance => instance;
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChangeEventCallBack;

    private Dictionary<ItemData, InventoryItem> _inventoryDictionary;
    public List<InventoryItem> inventory;

    private void Awake() {
        if(instance == null) {
            instance = this;
            inventory = new List<InventoryItem>();
            _inventoryDictionary = new Dictionary<ItemData, InventoryItem>();
        } else {
            Destroy(gameObject);
        }
    }

    public void Add(ItemData itemData) {
        if(_inventoryDictionary.TryGetValue(itemData, out InventoryItem item)) {
            item.AddCount();
        } else {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);

            _inventoryDictionary.Add(itemData, newItem);
        }
        OnInventoryChangeEventCallBack.Invoke();
    }

    public void Remove(ItemData itemData) {
        if(_inventoryDictionary.TryGetValue(itemData, out InventoryItem item)) {
            item.RemoveCount();
        }

        if (item.countItem == 0) {
            inventory.Remove(item);
            _inventoryDictionary.Remove(itemData);
        }
        OnInventoryChangeEventCallBack.Invoke();
    }

}
