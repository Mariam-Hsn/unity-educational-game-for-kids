using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Toggle backgroundMusicToggle;
    public Toggle soundEffectsToggle;
    public Slider volumeSlider;
    public Text volumeValueText;
    public GameObject settingsCanvas;
    public AudioSource backgroundMusic;//MA

    private const string MusicKey = "BackgroundMusic";
    private const string SoundEffectsKey = "SoundEffects";
    private const string VolumeKey = "Volume";
    public void Start()
    {
        // Load settings
        backgroundMusicToggle.isOn = PlayerPrefs.GetInt(MusicKey, 1) == 1;
        soundEffectsToggle.isOn = PlayerPrefs.GetInt(SoundEffectsKey, 1) == 1;
        volumeSlider.value = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        backgroundMusic.volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);//MA
        // Update volume text
        UpdateVolumeText();

        // Add listeners
        backgroundMusicToggle.onValueChanged.AddListener(OnBackgroundMusicToggle);
        soundEffectsToggle.onValueChanged.AddListener(OnSoundEffectsToggle);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    public void OnBackgroundMusicToggle(bool isOn)
    {
        PlayerPrefs.SetInt(MusicKey, isOn ? 1 : 0);
        backgroundMusic.mute = !isOn; //MA
        Debug.Log("Background Music: " + (isOn ? "On" : "Off"));
        // Add logic to enable/disable background music
    }

    public void OnSoundEffectsToggle(bool isOn)
    {
        PlayerPrefs.SetInt(SoundEffectsKey, isOn ? 1 : 0);
        Debug.Log("Sound Effects: " + (isOn ? "On" : "Off"));
        // Add logic to enable/disable sound effects
    }

    public void OnVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat(VolumeKey, value);
        UpdateVolumeText();
        backgroundMusic.volume = value;//MA
        Debug.Log("Volume: " + value);
        // Add logic to adjust volume
    }

    private void UpdateVolumeText()
    {
        volumeValueText.text = (volumeSlider.value * 100).ToString("0") + "%";
    }

    public void OnBackButtonClicked()
    {
        if (settingsCanvas != null)
            settingsCanvas.SetActive(false);
        else
            Debug.Log("Doesn't exist");
    }
}
