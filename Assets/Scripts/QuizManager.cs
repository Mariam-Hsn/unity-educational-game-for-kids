using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : MonoBehaviour {

	[SerializeField]
	private QuizUI quizUI;
    [SerializeField]//can edit from inspector
	private List<Question> Questions;
	Question selectedQuestion;

	int index = 0;

    // Use this for initialization
    void Start () {
		selectQuestion();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void selectQuestion()
	{
		//int index = Random.Range(0, Questions.Count);
		//Debug.Log(index);
		if (index == Questions.Count)
		{
			SceneManager.LoadScene("Score");
		}
		else
		{


			selectedQuestion = Questions[index];
			index++;
			quizUI.setQuestion(selectedQuestion);
		}
    }

	public bool Answer(string answer)
	{
		bool isCorrect = selectedQuestion.Answers[selectedQuestion.correctAnswerIndex] == answer;
		Invoke("selectQuestion", 0.4f);

		return isCorrect;
	}
}

[System.Serializable]
public class Question
{
	public Sprite questionImage;
	public List<string> Answers;
	public int correctAnswerIndex;
}
