using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSettings : MonoBehaviour {

	public GameObject settingsCanvas;
    public AudioSource backgroundMusic;
    public void Start()
    {
        int isOn = PlayerPrefs.GetInt("BackgroundMusic");//MA
        backgroundMusic.mute = isOn == 0; //MA
        backgroundMusic.volume = PlayerPrefs.GetFloat("Volume", 0.5f);//MA
    }
	public void EnableCanvas()
	{
		if (settingsCanvas != null)
			settingsCanvas.SetActive(true);
        else
            Debug.Log("Enable Doesn't exist");
    }

    public void OnBackButtonClicked()
    {
        if (settingsCanvas != null)
            settingsCanvas.SetActive(false);
        else
            Debug.Log("Doesn't exist");
    }
}
