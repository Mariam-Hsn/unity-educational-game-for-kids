using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleManager : MonoBehaviour {

	public void Alphabets()
	{
		SceneManager.LoadScene("AlphabetMain");
	}
	public void Numbers()
	{
		SceneManager.LoadScene("all_numbers"); 
	}
	public void Quizes()
	{
		SceneManager.LoadScene("quizes"); 
	}

}
