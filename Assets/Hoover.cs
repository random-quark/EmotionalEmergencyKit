using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoover : MonoBehaviour {
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void StartHoover () {
        StartCoroutine("Suck");
    }

    IEnumerator Suck() {
        while(true) {
            rb.AddForce(100, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
