using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    public Vector3 paddleToBallVector;
    private bool hasStarted = false, multiBallReady = false, launchMultiball = false;

    // Use this for initialization
    void Start() {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            lockToPaddle();
        } else if (multiBallReady) {
            if (!launchMultiball) {
                lockToPaddle();
            }
        }
    }
	public void lockToPaddle() {
        //Lock the ball relative to the paddle.
        transform.position = paddle.transform.position + paddleToBallVector;
        //wait for the mouse to be pressed to launch the ball.
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Mouse Clicked!");
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }
	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.5f), Random.Range (0f,0.5f));
		
		/* ball does not trigger sound when the ball strikes a brick that is ready to be destroyed
			not 100% sure why, could be because the brick is not there to trigger the sound*/
		if(hasStarted){
			GetComponent<AudioSource>().Play ();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
