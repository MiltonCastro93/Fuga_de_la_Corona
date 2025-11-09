
using UnityEngine;
using UnityEngine.AI;

public class SystemNavegation : MonoBehaviour {
    [SerializeField] private NavMeshAgent agent;
    private Vector3 TargetObject;
    private Vector3 waypoint;
    [SerializeField] private bool detectado = false;
    [SerializeField]private SystemAnimatorController SystemAnimatorController;
    private AudioSource AudioSource;

    //*updateRotation (True = Rotacion manual, Falso = Rotacion automatica)
    //*updatePosition (True = Movimiento Automatico, Falso = Movimiento Manual)
    //*isStopped (True = Detene el movimiento, Falso = segui el camino)
    void Start() {
        AudioSource = GetComponent<AudioSource>();
        //agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.isStopped = true;
    }

    //*ResetPath (cancelar la ruta actual)
    //*haspath (True = Camino calculado, Falso = no tiene camino)
    //*pathPending (True = Tiene un camino, Falso = no tiene camino)
    //*CalculatePath ( para verificar el camino sin mover la entidad )
    //*path.corners (matriz de curvas)
    //*destination ( usalo como lectura )
    //*steeringTarget (obtengo la curva mas proxima)
    void Update() {
        if (!agent.hasPath && !agent.pathPending && !detectado) {
            agent.SetDestination(TargetObject);
        }

        if (agent.hasPath && !agent.pathPending) {
            waypoint = agent.steeringTarget;
            Vector3 dir = (waypoint - transform.position).normalized;
            dir.y = 0f; // elimina inclinacion vertical
            dir = dir.normalized;

            float angle = Vector3.Angle(transform.forward, dir);

            float signedAngle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);
            if(signedAngle != 0f && agent.velocity.sqrMagnitude < 0f) {
                SystemAnimatorController.Turnlight(signedAngle);
            }


            SystemAnimatorController.Walking(agent.velocity.sqrMagnitude);

            if (angle < 5f) {
                agent.isStopped = false;
                AudioSource.Play();
                //agent.updatePosition = true;
            } else {
                AudioSource.Stop();
                agent.isStopped = true;
                //agent.updatePosition = false; // Pausa movimiento automatico
                Quaternion lookRot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
            }

        }

    }
    //*stoppingDistance = distancia de frenado

    public void positionDestination(Vector3 newPos) {
        TargetObject = newPos;
    }

    public void setStop(float Setfloat) {
        agent.stoppingDistance = Setfloat;
    }

    public void SoundAction(Vector3 newPos) {
        agent.SetDestination(newPos);
    }

    public void actionDetectado(Vector3 newPos) {
        detectado = true;
        agent.ResetPath();
        agent.SetDestination(newPos);
    }

}
