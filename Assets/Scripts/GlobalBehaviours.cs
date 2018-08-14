using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalBehaviours : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetButtonDown("LoadScene1"))
        {
            SceneManager.LoadScene("fantastic");
        }
        else if (Input.GetButtonDown("LoadScene2"))
        {
            SceneManager.LoadScene("AngryScene");
        }

	}
}
