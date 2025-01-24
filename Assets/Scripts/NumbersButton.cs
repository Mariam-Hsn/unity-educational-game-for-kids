using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NumbersButton : MonoBehaviour {


	public void GoToNumber(string s)
    {
        SceneManager.LoadScene("number"+s);
    }

	public void backToNumbers()
	{
        SceneManager.LoadScene("SampleScene");

    }
}
