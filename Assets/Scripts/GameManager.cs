using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [HideInInspector] public int score;
    [HideInInspector] public int winningScore;
    public Text Score;
    public Text finalScoreText;
    public Image GreyScreen;

    public Text gameOverText;               //Text that appears when a player is hit with 3 avoidable objects
    public Image gameOverPanel;             //Panel that appears when a player is hit with 3 avoidable objects
    public string loseByAvoidables;         //String value (determined in the Editor) alerting the player that they lost because they were hit by 3 avoidable objects
    public string TimeRanOut;               //String value (determined in the Editor) alerting the player that they lost because they ran out of time and did not get enough points

    public float timeCounter = 60;          //It's a float so I can subtract it from Time.deltaTime
    public int bonusTime;                   //used to add time to the clock and adds to your final score
    public Text timeText;

    public Button replay;
    public Button btnPause;
    public Button btnResume;
    public Button btnLevelSelector;
    public Button btnHatchery;
    public Button btnQuit;

    public AudioSource _audioSource;
    public AudioClip normalMusic;
    public AudioClip gameOverMusic;

    public bool pause;
    public bool gameOver;
    

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
        gameOverText.text = "";
        finalScoreText.text = "";
        Score.text = "";
        score = 0;
    }
}
