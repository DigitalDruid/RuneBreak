using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
    LevelManager levelManager { get { return (GameManager.instance.levelManager) ? GameManager.instance.levelManager :
                                             (LevelManager.instance)             ? LevelManager.instance             : FindObjectOfType<LevelManager>(); } }
    void Start()
    {
        //levelManager = GameManager.instance.levelManager;
    }
    void OnTriggerEnter2D (Collider2D trigger){
        switch (trigger.tag) {
            case "Ball":
                levelManager.LoseGame();
                break;
            case "PowerUp":
            default:
                Destroy(trigger);
                break;
        }
	}
}
