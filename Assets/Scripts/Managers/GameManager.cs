using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public LevelManager levelManager;
    public Paddle paddle;

    [SerializeField]
    public int startingLives = 2, startingLevel = 1, startingPower = 1;
    [SerializeField]
    public bool startSmall, startBig;

    public float padSpeed = 1.0f;
    public int ballPower = 1;

    private bool smPad, lgPad;
    public bool smallPaddle { get { return smPad; } set { smPad = value; if(smPad) largePaddle = false; } }
    public bool largePaddle { get { return lgPad; } set { lgPad = value; if (lgPad) smallPaddle = false; } }

    private int lives, score;
    public int playerLives { get { return lives; } set { lives = value; } }
    public int playerScore { get { return score; } set { score = value; } }

    private int curLevel;
    public int currentLevel { get { return curLevel; } set { curLevel = value; } }
    

	void Awake () {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        levelManager = FindObjectOfType<LevelManager>();
        paddle = FindObjectOfType<Paddle>();

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
}
