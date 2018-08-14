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
        if (Input.GetButtonDown("OpenGate") && rb)
        {
            Invoke("sendWord", 0.7f);
        }
        else if (Input.GetButton("Pump")) //revert to GetButton, when done
        {
            if (Input.GetButtonDown("Pump"))
            {
                pumpIncrement = 0;
                pumpAudio.Play();
                noOfPumps++;
            }
            if (pumpIncrement < Mathf.PI + 0.6){
                pumpPoint = Mathf.Sin(pumpIncrement)/80f;
                transform.localScale += new Vector3(pumpPoint,pumpPoint,pumpPoint);
                pumpIncrement += 0.1f;
                if (noOfPumps==3)
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
        else if (Input.GetButtonDown("Float")){
            foreach (Letter letter in letters)
            {
                //letter.setState(true);
            }
        }
    }

    void sendWord()
    {
        rb.AddForce(1000, 300, 0);
        rb.useGravity = true;
    }

    //void turnOffTriggerInWall(Collider col){
    //    col.gameObject.GetComponent<Collider>().isTrigger = false;
    //}
}