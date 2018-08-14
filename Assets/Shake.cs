using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    [SerializeField] Animator animator;

    public void DoShake() {
        animator.Play("Shake");
    }
}
