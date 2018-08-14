using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    [SerializeField] int direction = 1;
    bool gateActive = false;
    float sinPoint = 0;
    [SerializeField] Animator animator;
    [SerializeField] float speed = 0.5f;

	// Use this for initialization
	void Start () {
        animator.enabled = false;
        animator.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("OpenGate")){
            gateActive = true;
            animator.enabled = true;
        }

        //if (gateActive){
        //    float stepSize = 3;
        //    Vector3 offset = new Vector3 (0, Mathf.Sin(sinPoint)*stepSize, 0);
        //    transform.position += offset;
        //    sinPoint += 0.01f;
        //}
	}


}
