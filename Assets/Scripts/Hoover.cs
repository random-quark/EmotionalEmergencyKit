using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoover : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] AnimationCurve hooverSpeedCurve;
    [SerializeField] float totalHooverForce = 100;

    public int counter = 0;

    AudioSource audioSource;
    [SerializeField] AudioClip hoover;

    public float forceModifier;
    public float force;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    public void StartHoover () {
        StartCoroutine("Suck");
        audioSource.clip = hoover;
        audioSource.Play();
    }

    IEnumerator Suck() {
        while(true) {
            float floorWidth = GameObject.Find("Floor").transform.localScale.x;
            float distanceToExit = GameObject.Find("RightWall").transform.position.x - gameObject.transform.position.x;
            float progressToExit = (floorWidth-distanceToExit) / floorWidth;
            if (progressToExit > 1) break;
            print("width " + floorWidth);
            print("dist to exit" + distanceToExit);
            print("progress "+progressToExit);
            forceModifier = hooverSpeedCurve.Evaluate(progressToExit);
            print("force mod " + forceModifier);
            force = totalHooverForce * forceModifier;
            print("force" + force);
            rb.AddForce(force, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
