using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

    //public Rigidbody rb;
    bool allowFloat;
    Rigidbody rb;
    float _moveX, _moveZ;
    float _speed = 10;
    string _movementX, _movementZ;
    [SerializeField] ParticleSystem explosionParticles;

	// Use this for initialization
	void Start () {
        
        //rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //_moveX = Input.GetAxis(_movementX);
        //_moveZ = Input.GetAxis(_movementZ);
    }

	private void FixedUpdate()
	{
        if (rb)
        {
            //print(_moveX + "  " + _moveZ);
            Vector3 moveVector = new Vector3(0, 1f, 0) * _speed;
            print(moveVector);
            //rb.AddForce(moveVector, ForceMode.Acceleration);
            Vector3 childPosition = this.gameObject.transform.GetChild(0).position;
            rb.AddForceAtPosition(moveVector, childPosition, ForceMode.Acceleration);
        }
	}

	public void initRigidBody(){
        if (!rb) rb = gameObject.AddComponent<Rigidbody>();
    }

	void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "LeftWall") {
            print("helllll");   
        }

        if (collision.gameObject.tag == "Ceiling"){
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }	
	}
}
