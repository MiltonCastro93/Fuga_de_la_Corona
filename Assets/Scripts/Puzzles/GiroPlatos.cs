
using UnityEngine;

public class GiroPlatos : ManagerEvents, IEjecutePuzzle
{
    public GameObject Puzzle;
    public GameObject[] cubes = new GameObject[3];
    public GameObject[] platos = new GameObject[3];
    public GameObject selector;

    private int _newIndex = 0, _oldIndex = 0;
    private const float SpeedTurn = 6f, AngleTolerance = 5f;

    private bool PuzzleOK = false;

    public override void BeginPuzzle() {
        Puzzle?.SetActive(true);
        _newIndex = _oldIndex = 0;
    }

    public override void UpdatePuzzle() {
        HandleIndexInput();
        HandleRotationInput();

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (CheckPuzzleSolved()) {
                PuzzleOK = true;
                Debug.Log("¡Puzzle completado!");
                EndPuzzle();
            } else {
                Debug.Log("Aún no está bien alineado.");
            }
        }
    }

    private void HandleIndexInput() {
        if (Input.GetKeyDown(KeyCode.W)) _newIndex--;
        if (Input.GetKeyDown(KeyCode.S)) _newIndex++;

        _newIndex = Mathf.Clamp(_newIndex, 0, cubes.Length - 1);

        if (_oldIndex != _newIndex) {
            selector.transform.position = cubes[_newIndex].transform.position;
            _oldIndex = _newIndex;
        }
    }

    private void HandleRotationInput() {
        float turn = Input.GetAxis("Horizontal");
        if (Mathf.Abs(turn) < Mathf.Epsilon) { return; }

        float rotationAmount = turn * SpeedTurn * Time.deltaTime;

        switch (_newIndex) {
            case 0:
                RotatePlate(0, rotationAmount);
                RotatePlate(1, -rotationAmount);
                break;
            case 1:
                RotatePlate(0, rotationAmount);
                RotatePlate(1, rotationAmount);
                break;
            case 2:
                RotatePlate(2, rotationAmount);
                break;
        }
    }

    private void RotatePlate(int index, float amount) {
        if (index >= 0 && index < platos.Length) {
            platos[index].transform.Rotate(0f, 0f, amount);
        }
    }

    private bool CheckPuzzleSolved() {
        foreach (GameObject plato in platos) {
            float z = Mathf.Repeat(plato.transform.localEulerAngles.z, 360f);
            float diff = Mathf.Abs(z - 0f);
            if (diff > 180f) {
                diff = 360f - diff;
            }

            if (diff > AngleTolerance) {
                return false;
            }

        }
        return true;
    }

    public override void EndPuzzle() {
        Puzzle?.SetActive(false);
    }

    public bool IsPuzzle() {
        return PuzzleOK;
    }

}
