using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablesEnemy : MonoBehaviour {
    private List<Enemy> Interaccion = new List<Enemy>();
    [SerializeField] private float _angleMax = 45f;
    public LayerMask interes;

    private void FixedUpdate() {
        if (Interaccion.Count != 0) {
            foreach (Enemy enemy in Interaccion) {
                RaycastHit hit;

                if (Physics.Linecast(transform.parent.position, enemy.transform.position, out hit, interes,QueryTriggerInteraction.Ignore)) {
                    if (hit.collider == enemy.GetComponent<Collider>()) {
                        Vector3 directionToEnemy = (enemy.transform.position - transform.parent.position).normalized;
                        float angle = Vector3.Angle(transform.parent.forward, directionToEnemy);

                        //MeshRenderer renderer = enemy.GetComponent<MeshRenderer>();
                        //renderer.enabled = (angle <= _angleMax);

                        GameObject gameObject = enemy.GetComponent<Enemy>().visible;
                        gameObject.SetActive(angle <= _angleMax);

                        Debug.DrawLine(transform.parent.position, hit.point, Color.green);
                    } else {
                        //enemy.GetComponent<MeshRenderer>().enabled = false;
                        enemy.GetComponent<Enemy>().visible.SetActive(false);

                        Debug.DrawLine(transform.parent.position, hit.point, Color.yellow);
                    }
                } else {
                    //enemy.GetComponent<MeshRenderer>().enabled = false;
                    enemy.GetComponent<Enemy>().visible.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Entidad")) {
            Enemy enemigo = other.GetComponent<Enemy>();
            
            if (enemigo != null && !Interaccion.Contains(enemigo)) {                
                Interaccion.Add(enemigo);
            }
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Entidad")) {
            Enemy enemigo = other.GetComponent<Enemy>();

            if (enemigo != null && Interaccion.Contains(enemigo)) {
                //enemigo.GetComponent<MeshRenderer>().enabled = false;
                enemigo.GetComponent<Enemy>().visible.SetActive(false);
                Interaccion.Remove(enemigo);
            }
        }

    }

}
