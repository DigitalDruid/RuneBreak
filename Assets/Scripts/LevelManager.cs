using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load: " +name);
		Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
	}
	
	public void QuitRequest(){
		Debug.Log ("I want to Quit!!");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) LoadNextLevel();
	}
}
