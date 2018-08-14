using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
        print("COLLISION");
	}

	void OnCollisionExit(Collision other)
	{
        print("No longer in contact with " + other.transform.name);
  	}
}
