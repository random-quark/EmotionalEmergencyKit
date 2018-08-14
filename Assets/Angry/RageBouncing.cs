using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBouncing : MonoBehaviour
{
    Animator animator;
    bool landed = false;
    bool canJump = true;
    Rigidbody rb;

    AudioSource audioSource;
    [SerializeField] AudioClip roar;

    float lastShakeTime;

    public Shake cameraShake;

    int fireDirection = -1;

    int roarCount = 0;

    [SerializeField] float entryTime = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("OpenGate"))
        {
            Invoke("SendWord", entryTime);
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            canJump = false;
            Invoke("StartHoover", 3f);
        }
    }

    void StartHoover() {
        GetComponent<Hoover>().StartHoover();
        GameObject.Find("RightWall").GetComponent<Lift>().LiftUp();
    }


    void OnCollisionEnter(Collision coll)
    {
        float timeSinceShake = Time.time - lastShakeTime;
        if (CheckWallCollision(coll) && timeSinceShake > 1)
        {
            cameraShake.DoShake();
            lastShakeTime = Time.time;
        }


        if (landed)
            return;
        if (coll.gameObject.name == "Floor" || coll.gameObject.name == "RightWall")
        {
            Invoke("RunJumpAroundAfterDelay", 2);
            landed = true;
        }
    }

    bool CheckWallCollision(Collision coll) {
        List<string> walls = new List<string> { "RightWall", "TopGate", "BottomGate", "Floor", "Ceiling" };
        bool result = walls.Contains(coll.gameObject.name);
        return result;
    }

    IEnumerator JumpAround() {
        while(true) {
            if (!canJump) break;
            if (roarCount < 2) {
                audioSource.PlayOneShot(roar);
                roarCount++;
            }

            if (fireDirection > 0) {
                rb.AddForce(new Vector3(1500, 500, 0));
                fireDirection = -1;
            } else {
                rb.AddForce(new Vector3(-1500, 500, 0));
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
