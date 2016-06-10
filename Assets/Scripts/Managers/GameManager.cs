using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static LevelManager levelManager { get { return (!LevelManager.instance) ? FindObjectOfType<LevelManager>() : LevelManager.instance; } }

    public Paddle paddle;
    public Ball ball;

    [SerializeField]
    public int startingLives = 2, startingPower = 1;
    [SerializeField]
    public bool autoPlay, startSmall, startBig;

    public int startingLevel { get { return levelManager.startingLevel; } set { levelManager.startingLevel = value; } }
    public int currentLevel  { get { return levelManager.currentLevel; }  set { levelManager.currentLevel  = value; } }

    public float padSpeed = 1.0f;
    public int ballPower = 1;

    private bool smPad, lgPad;
    public bool smallPaddle { get { return smPad; } set { smPad = value; lgPad = !value; } }
    public bool largePaddle { get { return lgPad; } set { lgPad = value; smPad = !value; } }

    private int lives, score;
    public int playerLives { get { return lives; } set { lives = value; } }
    public int playerScore { get { return score; } set { score = value; } }
    
    

	void Awake () {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        //if(!levelManager) { levelManager = FindObjectOfType<LevelManager>(); }
        //if (!paddle) paddle = FindObjectOfType<Paddle>();
        //if (!ball) ball = FindObjectOfType<Ball>();
        
        //levelManager = FindObjectOfType<LevelManager>();
        paddle = FindObjectOfType<Paddle>();
        ball = FindObjectOfType<Ball>();

        playerLives = startingLives;
        currentLevel = startingLevel;

        if (startSmall) smallPaddle = true;
        if (startBig) largePaddle = true;

    }

    public void MultiBall() {
        Ball ball2 = new Ball();
        ball2.transform.position = paddle.transform.position + ball2.paddleToBallVector;
        ball2.gameObject.SetActive(true);
    }
    /*
    void OnLevelWasLoaded()
    {
        //if(!levelManager) { levelManager = FindObjectOfType<LevelManager>(); }
        if (!paddle) paddle = FindObjectOfType<Paddle>();
    }//*/
}
