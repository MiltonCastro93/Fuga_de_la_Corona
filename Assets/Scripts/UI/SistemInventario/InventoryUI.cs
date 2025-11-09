using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;

    // Start is called before the first frame update
    void Start() {
        InventorySystem.Instance.OnInventoryChangeEventCallBack += OnUpdateInventory;
    }

    private void OnUpdateInventory() {
        foreach (Transform t in transform) {
            Destroy(t.transform.gameObject);
        }
    }

    private void DrawInventory() {
        foreach(InventoryItem item in InventorySystem.Instance.inventory) {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item) {
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);

        ItemSlot slot = obj.GetComponent<ItemSlot>();
        if (slot != null) {
            slot.Set(item);
        }

    }

}
