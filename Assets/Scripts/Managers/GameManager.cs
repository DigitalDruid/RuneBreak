using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public LevelManager levelManager { get { return (LevelManager.instance) ? LevelManager.instance : FindObjectOfType<LevelManager>(); } }

    public Paddle paddle;
    public Ball ball;

    [SerializeField]
    public int startingLives = 2, startingPower = 1;
    [SerializeField]
    public bool autoPlay, startSmall, startBig;

    public int startingLevel { get { return levelManager.startingLevel; } set { levelManager.startingLevel = value; } }
    public int currentLevel  { get { return LevelManager.currentLevel; }  set { LevelManager.currentLevel  = value; } }

    public float padSpeed = 1.0f;
    public int ballPower = 1;

    private bool smPad, lgPad;
    public bool smallPaddle { get { return smPad; } set { smPad = value; lgPad = !value; } }
    public bool largePaddle { get { return lgPad; } set { lgPad = value; smPad = !value; } }

    private int lives, score;
    public int playerLives { get { return lives; } set { lives = value; } }
    public int playerScore { get { return score; } set { score = value; } }
    
    public static bool isRunning = false;

	void Awake () {
        if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); }
        
        paddle = FindObjectOfType<Paddle>();
        ball = FindObjectOfType<Ball>();

        playerLives = startingLives;
        playerScore = 0;
        currentLevel = startingLevel;

        if (startSmall) smallPaddle = true;
        if (startBig) largePaddle = true;

    }

    public void MultiBall() {
        Ball ball2 = new Ball();
        ball2.transform.position = paddle.transform.position + ball2.paddleToBallVector;
        ball2.gameObject.SetActive(true);
    }
}
