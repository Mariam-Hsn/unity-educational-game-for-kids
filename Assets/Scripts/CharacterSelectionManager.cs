using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CharacterSelectionManager : MonoBehaviour
{
	[Header("UI Elements")]
	public Text headerText;
	public Image characterImage;
	public Dropdown characterDropdown;
	public Button playButton;
	public Button settingsButton;
	public AudioSource backgroundMusic;

	[Header("Characters")]
	public Sprite[] characterSprites;
	public string[] characterNames;

	private int selectedCharacterIndex = 0;

	public void Start()
	{
		
        //int isOn =PlayerPrefs.GetInt("BackgroundMusic");//MA
        //backgroundMusic.mute = isOn == 0; //MA
        //backgroundMusic.volume = PlayerPrefs.GetFloat("Volume", 0.5f);//MA
        // Check if UI elements are assigned
        if (headerText == null || characterImage == null || characterDropdown == null || playButton == null || settingsButton == null)
		{
			Debug.LogError("UI elements not assigned in the inspector.");
			return;
		}

		// Check if the arrays are populated
		if (characterSprites.Length == 0 || characterNames.Length == 0)
		{
			Debug.LogError("Character sprites or names array is empty. Populate them in the Inspector.");
			return;
		}

		// Ensure the dropdown options match the arrays
		if (characterSprites.Length != characterNames.Length)
		{
			Debug.LogError("Character sprites and names arrays do not have the same length.");
			return;
		}


		// Initialize dropdown with character names
		InitializeDropdown();

		// Add listeners for dropdown and buttons
		characterDropdown.onValueChanged.AddListener(OnCharacterSelected);
		playButton.onClick.AddListener(OnPlayButtonClicked);
		//settingsButton.onClick.AddListener(OnSettingsButtonClicked);

		// Set initial dropdown value to 0
		characterDropdown.value = 0;
		selectedCharacterIndex = 0;

		// Update initial character display
		UpdateCharacterDisplay();
	}

	void InitializeDropdown()
	{
		characterDropdown.ClearOptions();

		if (characterNames.Length > 0)
		{
			List<string> options = new List<string>(characterNames);
			characterDropdown.AddOptions(options);
		}
		else
		{
			Debug.LogError("Character names array is empty. Cannot populate dropdown.");
		}
	}

	public void OnCharacterSelected(int index)
	{
		if (index >= 0 && index < characterSprites.Length)
		{
			selectedCharacterIndex = index;
			UpdateCharacterDisplay();
		}
		else
		{
			Debug.LogError("Invalid index selected: {index}. Ensure the dropdown value is within bounds.");
		}
	}

	void UpdateCharacterDisplay()
	{
		if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterSprites.Length)
		{
			characterImage.sprite = characterSprites[selectedCharacterIndex];
			headerText.text = "Choose Your Character: " + characterNames[selectedCharacterIndex];
		}
		else
		{
			Debug.LogError("Invalid selectedCharacterIndex: {selectedCharacterIndex}. Ensure it's within the bounds of the arrays.");
		}
	}

	public void OnPlayButtonClicked()
	{
		Debug.Log("Playing as " + characterNames[selectedCharacterIndex]);

		PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        SceneManager.LoadScene("SampleScene");
	}

	//public void OnSettingsButtonClicked()
	//{
	//	Debug.Log("Opening Settings Scene");
	//	SceneManager.LoadScene("Settings");
	//}
}
