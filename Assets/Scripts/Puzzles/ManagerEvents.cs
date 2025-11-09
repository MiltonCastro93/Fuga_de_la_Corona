using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerEvents : MonoBehaviour {
    public abstract void BeginPuzzle();
    public abstract void UpdatePuzzle();
    public abstract void EndPuzzle();

}
