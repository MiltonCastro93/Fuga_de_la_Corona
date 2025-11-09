using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private SphereCollider _sphere;
    [SerializeField] private Rigidbody rb;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start() {
        _sphere.enabled = false;
        rb.isKinematic = true;
        _audioSource = GetComponent<AudioSource>();
    }

    public void actionlaunch(float force) {
        rb.isKinematic = false;
        rb.AddForce(transform.parent.forward * force, ForceMode.Impulse);
        transform.SetParent(null);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Floor")) {
            _sphere.enabled = true;
            _audioSource.Play();
            Destroy(gameObject,2f);
        }

    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Entidad")) {
            other.GetComponentInChildren<EarListen>().sounditem(transform.position);
        }
    }

}
