using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    private MoveCharacter character;
    int maskToIgnore = ~(1 << 2 | 1 << 6 | 1 << 7); //< Hace un conjunto de capas. Ignorar la capa 2,6 & 7

    private void Start() {
        character = GetComponent<MoveCharacter>();
    }

    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, maskToIgnore)) {
            character.GetPointWorld(hit.point + Vector3.up);
        }

    }

}
