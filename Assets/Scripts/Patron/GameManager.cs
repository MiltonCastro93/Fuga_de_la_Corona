using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    private List<IObserver> observers = new List<IObserver>();
    public int ItemSound = 0;

    private void Awake() {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddObservador(IObserver observador) {
        if (!observers.Contains(observador)) {
            observers.Add(observador);
        }
    }

    public void DeleteObservador(IObserver observador) {
        if (observers.Contains(observador)) {
            observers.Remove(observador);
        }
    }

    public void UpdatesObservador() {
        foreach (var currentObservador in observers) {
            currentObservador.Ejecuted();
        }
    }

    public void AddCount(int value) {
        ItemSound += value;
        UpdatesObservador();
    }

    public void RemoveCount(int value) { 
        ItemSound = value;
        UpdatesObservador();
    }

}
