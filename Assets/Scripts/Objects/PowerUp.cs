using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    public const string NONE            = "",
                        EXTRA_LIFE      = "life",
                            LIFE        = "life",
                        PADDLE_SHRINK   = "small",
                            SMALL       = "small",
                        PADDLE_GROW     = "big",
                            BIG         = "big",
                        POWER           = "power",
                        SPEED           = "speed",
                        MULTI_BALL      = "multi",
                            MULTI       = "multi";

    public string type;
    public GameObject life, small, big, speed, power, multi;
    
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
                    GameManager.instance.smallPaddle = true;
                    break;
                case PADDLE_GROW:
                    GameManager.instance.largePaddle = true;
                    break;
                case MULTI_BALL:
                    GameManager.instance.MultiBall();
                    break;

            }
            Destroy(gameObject);
        }
    }
}
