using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Go(string letter)
    {
        SceneManager.LoadScene(letter+"Scene");
    }
	public void Back()
	{
        SceneManager.LoadScene("SampleScene");
    }
}
