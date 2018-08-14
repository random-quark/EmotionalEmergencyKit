using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entireWord : MonoBehaviour
{

    public float thrust;
    public Rigidbody rb;
    public Component[] letters;

    public float pumpIncrement;
    public float pumpPoint;
    int noOfPumps;
    [SerializeField] AudioSource pumpAudio;
    int maxPumps = 6;
    bool allowOnce = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        letters = GetComponentsInChildren<Letter>();
        pumpIncrement = 0;
        noOfPumps = 0;
    }

    //// Update is called once per frame
    void Update()
    {
    }

	private void FixedUpdate()
	{
        if (Input.GetButtonDown("OpenGate") && rb && allowOnce)
        {
            Invoke("sendWord", 0.7f);
            allowOnce = false;
        }
        else if (Input.GetButton("Pump")) //revert to GetButton, when done
        {
            if (Input.GetButtonDown("Pump"))
            {
                pumpIncrement = 0;
                pumpAudio.Play();
                noOfPumps++;
            }
            if (pumpIncrement < Mathf.PI + 0.6)
            {
                pumpPoint = Mathf.Sin(pumpIncrement) / 80f;
                transform.localScale += new Vector3(pumpPoint, pumpPoint, pumpPoint);
                pumpIncrement += 0.1f;
                if (noOfPumps == maxPumps)
                {
                    foreach (Letter letter in letters)
                    {
                        Destroy(GetComponent<Rigidbody>());
                        //letter.allowFloat = true;
                        letter.initRigidBody();
                    }
                }
            }
        }

	}

	void sendWord()
    {
        rb.AddForce(Random.Range(600, 1000), 300, 0);
        rb.useGravity = true;
    }

    //void turnOffTriggerInWall(Collider col){
    //    col.gameObject.GetComponent<Collider>().isTrigger = false;
    //}
}