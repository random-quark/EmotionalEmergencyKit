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

        if (Input.GetButtonDown("Restart")){
            reloadScene();
        }
        else if (Input.GetButtonDown("LoadScene1")){
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
        }
        else if (Input.GetButtonDown("LoadScene2"))
        {
            SceneManager.LoadScene("AngryScene");
        }

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