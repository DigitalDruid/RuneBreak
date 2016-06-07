using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public int curSceneIndex { get { return SceneManager.GetActiveScene().buildIndex; } }

    public void LoadLevel(string name){
		Debug.Log ("Level load: " + name);
		Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
	}
	
	public void QuitRequest(){
		Debug.Log ("I want to Quit!!");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
        SceneManager.LoadScene(curSceneIndex + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) LoadNextLevel();
	}

}
