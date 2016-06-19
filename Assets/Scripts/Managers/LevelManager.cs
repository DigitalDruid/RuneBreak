using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    const string START   = "Start", 
                 OPTIONS = "Options",
                 CREDITS = "Credits",
                 SELECT  = "StageSelect",
                 COLLECT = "Collectibles",
                 LEVEL   = "TestLevel", 
                 WIN     = "Win", 
                 LOSE    = "Lose";

    [SerializeField]
    public int startingLevel = 1;

    public static int currentLevel;
    public static int levels;

    public int curSceneIndex { get { return SceneManager.GetActiveScene().buildIndex; } }
    
    LoadSceneMode mode = LoadSceneMode.Single;

    // Use this for initialization
    void Awake() {
        MakeSingleton();
    }
    void MakeSingleton() {
        //if (instance == null) instance = this;
        if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); }
    }
    public void StartGame () {
        LoadLevel(SELECT);
    }
    public void GoToStart() {
        currentLevel = startingLevel;
        LoadLevel(START);
    }
    public void LoadLevel (string name, bool forceLoad=false){
        Brick.breakableCount = 0;
        if (!SceneManager.GetSceneByName(name).isLoaded || forceLoad) {
            unloadScene(name);
            Debug.Log("Load Scene: " + name);
            SceneManager.LoadScene(name, mode);
        } else {
            Debug.Log("GoTo Scene: " + name);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }
    }
    public void LoadLevel (int number) {
        GameManager.isRunning = false;
        unloadScene(LEVEL);
        Brick.breakableCount = 0;
        Debug.Log("Load Scene: " + LEVEL + " (" + number + ")");
        currentLevel = number;
        SceneManager.LoadScene(LEVEL);
    }
	public void QuitRequest(){
		Debug.Log ("I want to Quit!!");
		Application.Quit();
	}	
	public void LoadNextLevel(){
        ProgressManager.completedLevels = currentLevel;
        ProgressManager.setScore(currentLevel, GameManager.instance.playerScore);
        GameManager.instance.playerScore = 0;
        if (currentLevel < levels) {
            currentLevel++;
            LoadLevel(LEVEL, true);
        } else {
            LoadLevel(WIN);
        }
	}	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) LoadNextLevel();
	}
    public void LoseGame() {
        GameManager.isRunning = false;
        foreach (Object obj in GetComponents<PowerUp>()) { Destroy(obj); }
        foreach (Object obj in GetComponents<MultiBrick>()) { Destroy(obj); }
        foreach (Object obj in GetComponents<Brick>()) { Destroy(obj); }
        foreach (Object obj in GetComponents<Ball>()) { Destroy(obj); }

        LoadLevel(LOSE);
    }
    public void unloadScene(string name){
       // if (SceneManager.GetSceneByName(name).isLoaded) SceneManager.UnloadScene(name);
    }
}