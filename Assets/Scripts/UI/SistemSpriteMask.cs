using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemSpriteMask : MonoBehaviour, IObserver
{
    private SpriteMask mask;
    private float currentProgre = 1.2f;
    private float MaxProgre = 0f;
    [SerializeField]private bool action = false;
    public GameObject activarLooser;

    void Start() {
        mask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update() {
        if (action) {
            currentProgre -= Time.deltaTime;
            currentProgre = Mathf.Clamp(currentProgre, MaxProgre, currentProgre);
            mask.transform.localScale = new Vector3(currentProgre, currentProgre, 1f);
            Invoke("Restar",3f);
        }

    }

    public void Ejecuted() {
        action = true;
    }

    private void Restar() {
        activarLooser.SetActive(true);
    }

}
