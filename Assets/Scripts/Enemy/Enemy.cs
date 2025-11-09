using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {
    private enum Status {Patrol, Suspicios, Detection }
    [SerializeField] Status CurrentStatus;
    private SystemNavegation navAgent;
    [SerializeField] private SpriteRenderer MeshCono;

    [SerializeField] private bool heard = false;
    [SerializeField] private Vector3 pointHeard = Vector3.zero;

    public Vector3 LimitedPatrolM2;
    public GameObject visible;

    // Start is called before the first frame update
    void Start() {
        navAgent = GetComponent<SystemNavegation>();
        CurrentStatus = Status.Patrol;

        //GetComponent<MeshRenderer>().enabled = false;
        visible.SetActive(false);
        MeshCono.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        switch (CurrentStatus) {
            case Status.Patrol:
                navAgent.positionDestination(PointNewDestination());
                break;
            case Status.Suspicios:
                if(heard) {
                    float distancia = (pointHeard - transform.position).magnitude;
                    if (distancia <= 2f) {
                        heard = false;
                        CurrentStatus = Status.Patrol;
                    }
                }

                break;
            case Status.Detection:
                if (!GetComponent<MeshRenderer>().enabled) {
                    //GetComponent<MeshRenderer>().enabled = true;
                    visible.SetActive(true);
                }

                break;

        }
        //visible.SetActive(true);//<Sacar esto cuando finalice el test animations
        MeshCono.enabled = GetComponent<MeshRenderer>().enabled;
    }

    public void SoundDestination(Vector3 SoundPoint) {
        if(CurrentStatus != Status.Detection) {
            pointHeard = SoundPoint;
            navAgent.SoundAction(SoundPoint);
            CurrentStatus = Status.Suspicios;
            heard = true;
        }

    }

    public void getPlayer(GameObject gameObject) {
        if(CurrentStatus != Status.Detection) {
            gameObject.GetComponent<MoveCharacter>().youloose = true;
            navAgent.actionDetectado(gameObject.transform.position);
            CurrentStatus = Status.Detection;
        }

    }

    private Vector3 PointNewDestination() {
        Vector3 localOffset = new Vector3(
            Random.Range(-LimitedPatrolM2.x, LimitedPatrolM2.x),
            0f,
            Random.Range(-LimitedPatrolM2.z, LimitedPatrolM2.z)
        );

        // Convertimos la posición local al espacio global
        Vector3 worldPos = localOffset;

        if (transform.parent != null) {
            worldPos = transform.parent.TransformPoint(localOffset);
        }

        return worldPos;
    }

}
