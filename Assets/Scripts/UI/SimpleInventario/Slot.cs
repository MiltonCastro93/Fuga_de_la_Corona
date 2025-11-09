
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour, IObserver {
    public TextMeshProUGUI countBotellas;

    private void Start() {
        GameManager.Instance.AddObservador(this);
    }


    public void Ejecuted() {
        ValueUpdate(GameManager.Instance.ItemSound);
    }

    public void ValueUpdate(int value) {
        countBotellas.text = value.ToString();
    }


}
