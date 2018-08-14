using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBouncing : MonoBehaviour
{
    Animator animator;
    bool landed = false;
    Rigidbody rb;

    public Shake cameraShake;

    int fireDirection = -1;

    [SerializeField] float entryTime = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("OpenGate"))
        {
            Invoke("SendWord", entryTime);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        
        if (CheckWallCollision(coll) && timeSinceShake > 500)
        {
            cameraShake.DoShake();
        }


        if (landed)
            return;
        if (coll.gameObject.name == "Floor" || coll.gameObject.name == "RightWall")
        {
            print("entered coll");
            Invoke("RunJumpAroundAfterDelay", 2);
            //StartCoroutine("Jitter");
            landed = true;
        }


    }

    bool CheckWallCollision(Collision coll) {
        List<string> walls = new List<string> { "RightWall", "TopGate", "BottomGate" };
        bool result = walls.Contains(coll.gameObject.name);
        return result;
    }


    IEnumerator JumpAround() {
        while(true) {
            if (fireDirection > 0) {
                rb.AddForce(new Vector3(1000, 500, 0));
                fireDirection = -1;
            } else {
                rb.AddForce(new Vector3(-1000, 500, 0));
                fireDirection = 1;
            }
            yield return new WaitForSeconds(Random.Range(0.8f, 1.6f));
        }
    }

    IEnumerator Jitter() {
        while (true) {
            if (Random.value > 0.5)
            {
                rb.AddForce(new Vector3(100, 0, 0));
            }
            else
            {
                rb.AddForce(new Vector3(-100, 0, 0));
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    void RunJumpAroundAfterDelay() {
        StartCoroutine("JumpAround");
    }

    void StartAngryAnimation()
    {
        animator.SetBool("jitterOn", true);
    }

    void HooverOut()
    {
        animator.SetBool("hooverOn", true);
    }

    void SendWord()
    {
        print("send the word");
        rb.AddForce(1000, 100, 0);
        rb.useGravity = true;
    }
}
