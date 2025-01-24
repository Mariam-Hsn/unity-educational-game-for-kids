using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour {

    [SerializeField]
    private QuizManager quizManager;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private List<Button> options;

    [SerializeField]
    private Text Score;

    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource audioSource;

    public Slider slider;
    float timeLeft = 1 * 30; //2 Minutes


    // private Question question;
    // private  bool answered;
    private int scoreCount = 0;
    
    // Use this for initialization
    void Start () {
        scoreCount = 0;
        Score.text = "0";
        PlayerPrefs.SetString("Score", Convert.ToString(scoreCount));
        slider.maxValue = timeLeft;
        slider.value = timeLeft;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update ()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft > 0)
        {
            slider.value = timeLeft;
        }
        else
        {
           //PlayerPrefs.SetString("score", "GameOver");
            SceneManager.LoadScene("Score");
        }

    }



	void Awake () {
        for (int i = 0; i < options.Count; i++)
        {
            Button button = options[i];
            button.onClick.AddListener(() => onClick(button));
        }
		
	}
    public void setQuestion(Question question)

    {
       // Debug.Log(question.Answers[1]);
      //  this.question = question;
        questionImage.sprite = question.questionImage;
        for(int i= 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = question.Answers[i];
            options[i].name = question.Answers[i];
        }

       // answered = false;

    }

    private void onClick(Button button)
    {
        bool ans = quizManager.Answer(button.name);
      if(ans)
        {
            PlaySound(correctSound);
            scoreCount += 20;
            Score.text = Convert.ToString(scoreCount);
            PlayerPrefs.SetString("Score", Convert.ToString(scoreCount));
        }
        else
        {
            PlaySound(incorrectSound);
            PlayerPrefs.SetString("Score", Convert.ToString(scoreCount));
        }

    }

    void PlaySound(AudioClip clip)
    {

        audioSource.PlayOneShot(clip);

    }


}
