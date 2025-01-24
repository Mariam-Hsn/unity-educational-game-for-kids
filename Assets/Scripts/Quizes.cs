using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Quizes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goTo(string quiz)
	{
		SceneManager.LoadScene(quiz);
	}

	public void back()
	{
        SceneManager.LoadScene("SampleScene");
    }
}
