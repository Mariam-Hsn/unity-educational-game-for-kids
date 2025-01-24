using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BackToAlphabets()
    {
        SceneManager.LoadScene("AlphabetMain");
    }
    public void BackToNumbers()
    {
        SceneManager.LoadScene("all_numbers");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
