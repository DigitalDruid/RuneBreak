using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance;
	
	void Awake(){
		if (instance != null){
			Destroy (gameObject);
			Debug.Log("Duplicate music player self-destructing!");
		} else {
			instance = this;
            DontDestroyOnLoad(gameObject);
		}
		Debug.Log("Music player Awake " + GetInstanceID());
		Debug.Log("Music player Start " + GetInstanceID());
	}
}
