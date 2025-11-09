using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ControlHide : MonoBehaviour {
    [SerializeField] private Vector3 _preHide = Vector3.zero;
    private MoveCharacter _character;
    private GameObject Ocultar;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _character = other.GetComponent<MoveCharacter>();
            Ocultar = other.GetComponent<MoveCharacter>().PersonVisible;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {

            if (Input.GetButtonDown("Interaction") && !_character.StatusHide()) {
                _preHide = _character.transform.position;
                //_character.GetComponent<MeshRenderer>().enabled = false;

                Ocultar.SetActive(false);
                other.transform.position = transform.position;
                _character.IsHide(true);
            }

            if (Input.GetButtonDown("Cancel") && _character.StatusHide()) {
                //_character.GetComponent<MeshRenderer>().enabled = true;

                Ocultar.SetActive(true);
                _character.transform.position = _preHide;
                _character.IsHide(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (_character != null && other.CompareTag("Player")) {
            _character = null;
            Ocultar = null;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(_preHide, Vector3.one * 0.25f);
    }

}
