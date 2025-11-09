using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConoVision : MonoBehaviour
{
    private bool activeCono = false, playerInHide = false;
    private bool DetectedAlert = false;
    private MoveCharacter Player;
    [SerializeField] private float AngleMax = 45;
    [SerializeField] private LayerMask layerPlayer;

    private void FixedUpdate() {
        if (activeCono && !playerInHide) {
            RaycastHit hit;

            Vector3 posRelative = (Player.transform.position - transform.position).normalized;
            if(Physics.Raycast(transform.position, posRelative, out hit, Mathf.Infinity,layerPlayer, QueryTriggerInteraction.Ignore)) {
                if (hit.collider.CompareTag("Player")) {
                    float angleCurrent = Vector3.Angle(transform.forward, posRelative);

                    if(angleCurrent <= AngleMax && !DetectedAlert) {
                        Debug.Log("Derrota");
                        DetectedAlert = true;
                        GetComponentInParent<Enemy>().getPlayer(Player.gameObject);
                    }

                    Debug.DrawLine(transform.position, hit.point, Color.blue);
                }

            }

        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            activeCono = true;
            Player = other.GetComponent<MoveCharacter>();
        }
    }

    private void OnTriggerStay(Collider other) {
        if(Player != null) {
            playerInHide = Player.StatusHide();
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            activeCono = false;
            Player = null;
        }

    }

}
