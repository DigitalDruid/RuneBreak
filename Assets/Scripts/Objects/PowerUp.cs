using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    public const string EXTRA_LIFE = "life",
                        PADDLE_SHRINK = "small",
                        PADDLE_GROW = "big",
                        POWER = "power",
                        SPEED = "speed",
                        MULTI_BALL = "multi",
                        NONE = "";

    public string type;
    public GameObject life, small, big, speed, power, multi;

    void Start() { }
    void Awake() { }
    void Update() {
        Vector3 pos = transform.position;
        pos.y += 0.1f;
        transform.position.Set(pos.x, pos.y, pos.z);
    }

    void OnTriggerEnter2D (Collider2D target) {
        if (target.tag == "Paddle") {
            switch (type) {
                case EXTRA_LIFE:
                    GameManager.instance.playerLives++;
                    break;
                case SPEED:
                    GameManager.instance.padSpeed++;
                    break;
                case POWER:
                    GameManager.instance.ballPower++;
                    break;
                case PADDLE_SHRINK:
                    GameManager.instance.smallPaddle=true;
                    break;
                case PADDLE_GROW:
                    GameManager.instance.largePaddle = true;
                    break;
                case MULTI_BALL:
                    GameManager.instance.MultiBall();
                    break;

            }
        }
    }
}
