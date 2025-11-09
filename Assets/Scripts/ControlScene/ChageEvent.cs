using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageEvent : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            NewMap();
        }

    }


    public void NewMap() {
        SceneManager.LoadScene(index);

    }

}
