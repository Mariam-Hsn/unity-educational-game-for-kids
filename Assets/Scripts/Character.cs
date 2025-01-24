using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour {
    public Sprite[] characterSprites;
	public Image CharacherImage;
    // Use this for initialization
    void Start () {
		int indx = PlayerPrefs.GetInt("SelectedCharacter");
		Debug.Log(indx);
		CharacherImage.sprite = characterSprites[indx];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
