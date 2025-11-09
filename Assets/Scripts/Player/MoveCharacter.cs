using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class MoveCharacter : MonoBehaviour
{
    private CharacterController _cC;
    private Vector3 GetMouse = Vector3.zero;
    [SerializeField] private bool _isGround = false;
    [SerializeField] float speed = 2f, radius = 2f, speedCrounch = 2f;
    [SerializeField] private bool _Ocupped = false, _isHide = false;
    public bool youloose = false;
    [SerializeField] UnityEvent OnPlayerDetected;
    public GameObject PersonVisible;
    private SystemPlayerAnimations systemAnimator;

    public bool CancelAction {  get { return youloose; } }

    void Start() {
        _cC = GetComponent<CharacterController>();
        systemAnimator = GetComponentInChildren<SystemPlayerAnimations>();
    }


    void Update() {
        if (youloose) {
            OnPlayerDetected?.Invoke();
            return;
        }
            
        if (!_Ocupped) {
            if (!_isHide) {
                _isGround = Input.GetButton("Crouched");//animacion y condiciones

                float distance = Vector3.Distance(transform.position, GetMouse);
                float moveX = Input.GetAxisRaw("Horizontal");
                float inputZ = Input.GetAxisRaw("Vertical");
                float moveZ = 0f;
                float speedCurrent = 0f;

                if (distance > radius || inputZ < 0f) {
                    moveZ = inputZ;
                }

                if (_isGround) {
                    speedCurrent = speedCrounch;
                } else {
                    speedCurrent = speed;
                }

                Vector3 direction = (transform.forward * moveZ) + (transform.right * moveX);
                systemAnimator?.Walking(direction.z);
                systemAnimator?.Strafe(direction.x);

                _cC?.SimpleMove(direction.normalized * speedCurrent * Time.deltaTime);
            }
            transform.LookAt(GetMouse);
        }

    }

    public void GetPointWorld(Vector3 Point) {
        GetMouse = Point;
    }

    public void IsOcupped(bool SetBool) {
        _Ocupped = SetBool;
    }

    public void IsHide(bool SetBool) {
        _isHide = SetBool;
    }

    public bool StatusHide() {
        return _isHide;
    }

    public bool runSound() {        
        if (_isGround) {
            return false;
        } else {
            Vector3 horizontalVelocity = new Vector3(_cC.velocity.x, 0f, _cC.velocity.z);
            return horizontalVelocity.sqrMagnitude > 0.01f;
        }
    }

    public Vector3 CurrentPos() {
        return transform.position;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetMouse, 0.2f);
    }



}
