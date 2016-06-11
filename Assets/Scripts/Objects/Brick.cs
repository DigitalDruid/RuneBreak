using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public MultiBrick parent;
    public MultiBrick Parent { get { return parent; } set { parent = value; } }

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

    LevelManager levelManager { get { return (GameManager.instance.levelManager) ? GameManager.instance.levelManager :
                                             (LevelManager.instance)    ? LevelManager.instance    : FindObjectOfType<LevelManager>(); } }

    private bool isBreakable;
	
	private int timesHit;
	
	// Use this for initialization
	void Start () {
		isBreakable = (tag == "Breakable");

		//keep track of breakable bricks
		if (isBreakable) breakableCount++;

		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () { }
	
	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		if (isBreakable) HandleHits();
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			Debug.Log (breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
            Destroy(Parent);
		}else{
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] !=null){
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Sprite Missing for brick!");
		}
	}
	
	//TODO Remove this method once we can actually win
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
