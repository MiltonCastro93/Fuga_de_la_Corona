using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAnimatorController : MonoBehaviour {
    [SerializeField] private Animator mAnimator;

    private void Start() {
        mAnimator = GetComponent<Animator>();
    }

    public void Walking(float speed) {
        mAnimator.SetBool("Walking", speed >= 0.01f);
    }

    public void Turnlight(float angle) {
        if(angle >= 0.01f) {
            mAnimator.Play("TurnRight");
        }else if(angle <= -0.01f) {
            mAnimator.Play("TurnLeft");
        } else {
            Debug.Log("Nulo");
        }
    }

    public bool GetAnimation() {
        AnimatorStateInfo stateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Walking");
    }

}
