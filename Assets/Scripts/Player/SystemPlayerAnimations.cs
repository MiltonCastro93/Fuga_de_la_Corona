using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayerAnimations : MonoBehaviour
{
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void Walking(float speed) {
        animator.SetBool("Walking", speed > 0.01f);
        animator.SetBool("BackWalking", speed <= -0.01f);
    }

    public void Strafe(float X) {
        animator.SetBool("StrafeRigh", X > 0.01f);
        animator.SetBool("StrageLeft", X <= -0.01f);
    }

}
