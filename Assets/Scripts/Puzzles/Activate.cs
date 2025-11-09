using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {
    [SerializeField] private ManagerEvents ejecutePuzzle;
    private IEjecutePuzzle uniqueEvent;
    private bool _active = false;

    private void Start() {
        ejecutePuzzle = GetComponent<ManagerEvents>();
        uniqueEvent = (IEjecutePuzzle)ejecutePuzzle;
    }

    private void Update() {
        if (_active) {
            ejecutePuzzle?.UpdatePuzzle();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if (Input.GetButtonDown("Interaction") && !_active) {
                _active = true;
                ejecutePuzzle?.BeginPuzzle();
            }
            if (Input.GetButtonDown("Cancel") || uniqueEvent.IsPuzzle() || other.GetComponent<MoveCharacter>().CancelAction) {
                _active = false;
                ejecutePuzzle?.EndPuzzle();
            }

            other.GetComponent<MoveCharacter>().IsOcupped(_active);
        }
    }

}
