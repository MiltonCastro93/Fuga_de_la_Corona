using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBottle : MonoBehaviour
{

    public ItemData itemData;



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PickUp();
        }
    }

    public void PickUp() {
        InventorySystem.Instance.Add(itemData);
        Destroy(gameObject);
    }


}
