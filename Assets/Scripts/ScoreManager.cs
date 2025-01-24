using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour {

	public Text Score;

	// Use this for initialization
	void Start () {
		Score.text = "Your Final Score is \n "+PlayerPrefs.GetString("Score");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
