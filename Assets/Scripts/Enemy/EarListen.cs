using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarListen : MonoBehaviour {
    private Enemy entidad;
    private MoveCharacter character;

    // Start is called before the first frame update
    void Start() {
        entidad = transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            character = other.GetComponent<MoveCharacter>();
        }
    }


    private void OnTriggerStay(Collider other) {
        if(character != null) {
            if (character.runSound()) {
                entidad.SoundDestination(character.CurrentPos());
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        character = null;
    }

    public void sounditem(Vector3 posSound) {//deteccion de items
        entidad.SoundDestination(posSound);
    }

}
