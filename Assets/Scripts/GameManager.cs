using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MovementEffects;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [HideInInspector] public int score;
    //public int winningScore;
    public Text scoreText;
    public Text finalScoreText;

    public Image greyScreen;
    public Text gameOverText;               //Text that appears when a player is hit with 3 avoidable objects
    public Image gameOverPanel;             //Panel that appears when a player is hit with 3 avoidable objects
    [HideInInspector] public string loseByAvoidables;         //String value (determined in the Editor) alerting the player that they lost because they were hit by 3 avoidable objects
    [HideInInspector] public string TimeRanOut;               //String value (determined in the Editor) alerting the player that they lost because they ran out of time and did not get enough points

    public Text countdownBeginTimer;
    //public Text timeText;
    //public float timeCounter = 60;          //It's a float so I can subtract it from Time.deltaTime
    //public int bonusTime;                   //used to add time to the clock and adds to your final score
    

    //public Button replay;
    //public Button btnPause;
    //public Button btnResume;
    //public Button btnQuit;

    //public AudioSource _audioSource;
    //public AudioClip normalMusic;
    //public AudioClip gameOverMusic;

    [HideInInspector] public bool pause;
    [HideInInspector] public bool gameOver;
    

    void Awake()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        countdownBeginTimer.text = "3";
        gameOverPanel.gameObject.SetActive(false);
        gameOverText.text = "";
        finalScoreText.text = "";
        scoreText.text = "";
        score = 0;
        greyScreen.gameObject.SetActive(false);

        Timing.RunCoroutine(_Countdown());

        gameOver = false;
        pause = false;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void Pause()
    {

    }

    public void GameOver()
    {

    }

    IEnumerator<float> _Countdown()
    {
        yield return Timing.WaitForSeconds(1f);
        countdownBeginTimer.GetComponent<Text>().color = new Color(0.75f, 0, 0);
        countdownBeginTimer.text = "2";
        yield return Timing.WaitForSeconds(1f);
        countdownBeginTimer.GetComponent<Text>().color = new Color(0.75f, 0.75f, 0);
        countdownBeginTimer.text = "1";
        yield return Timing.WaitForSeconds(1f);
        countdownBeginTimer.GetComponent<Text>().color = new Color(0, 0.5f, 0);
        countdownBeginTimer.text = "GO!";
        yield return Timing.WaitForSeconds(1f);
        countdownBeginTimer.text = "";
    }
}
