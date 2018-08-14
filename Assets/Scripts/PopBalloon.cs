using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopBalloon : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    int totalCollisions = 0;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (totalCollisions == 5) Invoke("reloadScene", 4);
	}

	void OnCollisionEnter(Collision collision)
	{
        audioSource.Play();
        totalCollisions++;
    }

    void reloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}