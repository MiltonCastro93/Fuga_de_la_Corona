using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponentInChildren<LaunchItem>().valueIndex++;
            GameManager.Instance.AddCount(1);
            Destroy(gameObject);
        }
    }

}
