using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene("CharacterSelection");
	}

	public void OpenSettings()
	{
		SceneManager.LoadScene("Settings"); 
	}

	public void ExitGame()
	{
		Debug.Log("Exiting Game!");
		Application.Quit(); // Exits the application
	}
}
