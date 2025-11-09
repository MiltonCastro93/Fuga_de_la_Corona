using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActionsManager : MonoBehaviour
{
    private static ItemActionsManager instance;
    public static ItemActionsManager Instance => instance;
    private InventoryItem _selectedItem;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

    }

    public void UseSelectedItem(InventoryItem item) {
        if (_selectedItem == null) return;
        Debug.Log($"Usando {_selectedItem.data.ItemName}.");

        InventorySystem.Instance.Remove(_selectedItem.data);

    }

    public void RemoveSelectedItem(InventoryItem item) { 
        if (_selectedItem == null) return;
        Debug.Log($"Usando {_selectedItem.data.ItemName}.");

        Vector3 dropPosition = Camera.main.transform.position + Camera.main.transform.forward * 2;
        Instantiate(_selectedItem.data.ItemPrefab, dropPosition, Quaternion.identity);
        InventorySystem.Instance.Remove(_selectedItem.data);
    }
}
