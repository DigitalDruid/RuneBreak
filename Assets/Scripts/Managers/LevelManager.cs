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
    [HideInInspector]
    public int currentLevel, levels;

    public int curSceneIndex { get { return SceneManager.GetActiveScene().buildIndex; } }
    
    LoadSceneMode mode = LoadSceneMode.Single;

    // Use this for initialization
    void Awake() {
        MakeSingleton();
        currentLevel = startingLevel;
    }
    void MakeSingleton() {
        if (instance == null) instance = this;
        //if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); }
    }
    public void StartGame () {
        LoadLevel(SELECT);
    }
    public void GoToStart() {
        LoadLevel(START);
    }
    public void LoadLevel (string name, bool forceLoad=false){
        Brick.breakableCount = 0;
        if (!SceneManager.GetSceneByName(name).isLoaded || forceLoad) {
            unloadScene(name);
            Debug.Log("Load Sceme: " + name);
            SceneManager.LoadScene(name/*, mode*/);
        } else {
            Debug.Log("GoTo Scene: " + name);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }
    }
    public void LoadLevel (int number) {
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
        if (currentLevel < levels) {
            currentLevel++;
            LoadLevel(LEVEL, true);
        } else {
            LoadLevel(WIN);
        }
        //SceneManager.LoadScene(curSceneIndex + 1);
	}	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) LoadNextLevel();
	}
    public void unloadScene(string name){
       // if (SceneManager.GetSceneByName(name).isLoaded) SceneManager.UnloadScene(name);
    }
}