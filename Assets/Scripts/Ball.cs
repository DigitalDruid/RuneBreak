using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
			paddle = GameObject.FindObjectOfType<Paddle>();
			paddleToBallVector = this.transform.position - paddle.transform.position;
		}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			//wait for the mouse to be pressed to launch the ball.
			if(Input.GetMouseButtonDown(0)){
				Debug.Log("Mouse Clicked!");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range (0f,0.2f));
		
		/* ball does not trigger sound when the ball strikes a brick that is ready to be destroyed
			not 100% sure why, could be because the brick is not there to triger the sound*/
		if(hasStarted){
			GetComponent<AudioSource>().Play ();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
