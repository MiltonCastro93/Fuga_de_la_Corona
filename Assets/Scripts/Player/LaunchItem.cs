using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchItem : MonoBehaviour
{
    [SerializeField] private float forcethrow = 0f, forceMax = 2f;
    private GameObject currentItem;
    private bool chargePower = true;
    public GameObject itemPrefab;
    public int valueIndex = 0;
    public GameObject UILaunch;
    private Slider barPower;

    private void Start() {
        barPower = UILaunch.GetComponent<Slider>();
        barPower.maxValue = forceMax;
        UILaunch.SetActive(false);
    }

    void Update() {
        if(valueIndex > 0) {
            if (currentItem == null) {
                currentItem = Instantiate(itemPrefab);
                currentItem.transform.SetParent(transform, false);
            }
            if (Input.GetMouseButton(1) && chargePower) {
                UILaunch.SetActive(true);
                forcethrow += Time.deltaTime;
                forcethrow = Mathf.Clamp(forcethrow, 0.01f, forceMax);

            }

            if (Input.GetMouseButtonUp(1)) {
                forcethrow = 0f;
                chargePower = true;
                UILaunch.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && forcethrow > 0.01f) {
                Action();
            }

            barPower.value = forcethrow;

        }

    }

    private void Action() {
        currentItem?.GetComponent<Bottle>().actionlaunch(forcethrow);
        forcethrow = 0f;
        valueIndex--;
        chargePower = false;
        GameManager.Instance.RemoveCount(valueIndex);
    }

}
