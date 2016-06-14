using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay {
        get { return GameManager.instance.autoPlay; }
        set { GameManager.instance.autoPlay = value; }
    }
	public float minX, maxX;

    private Ball ball;

    public int size = 2;
    public void grow() {   size += (size < 3) ? 1 : 0; }
    public void shrink() { size -= (size > 1) ? 1 : 0; }

	void Start(){
		ball = FindObjectOfType<Ball>();

        if (GameManager.instance.startBig) { grow(); }
        else if (GameManager.instance.startSmall) { shrink(); }

        Debug.Log(transform.localScale.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) MoveWithMouse(); else AutoPlay();

        Vector3 trans = FindObjectOfType<Transform>().localScale;
        
        if (size == 1) trans.Set(0.5f, 1.0f, 1.0f);
        if (size == 2) trans.Set(1.0f, 1.0f, 1.0f);
        if (size == 3) trans.Set(2.0f, 1.0f, 1.0f);
    }

    void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        transform.position = paddlePos;
	}
	
	void MoveWithMouse (){
		Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        transform.position = paddlePos;
	}
}
