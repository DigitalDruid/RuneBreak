using UnityEngine;
using System.Collections;

public class MultiBrick : MonoBehaviour {

    public const string RED = "red", GREEN = "green", BLUE = "blue", GREY = "grey";

    [SerializeField]
    public string type = RED;
    public string powerupType;
    public Brick red, green, blue, grey;
    public PowerUp powerUp;

	// Use this for initialization
	void Start () {
        setBrickType();
        setPowerUpType();
	}
	void Awake() {
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnDestroy() {
        powerUp.gameObject.SetActive(true);
    }

    void setBrickType() {
        Brick bb;
        switch (type) {
            case GREEN:
                bb = inst(green) as Brick; break;
            case BLUE:
                bb = inst(blue) as Brick; break;
            case GREY:
                bb = inst(grey) as Brick; break;
            case RED: default:
                bb = inst(red) as Brick; break;
        }
    }

    void setPowerUpType() {
        powerUp.type = powerupType;
        PowerUp pp;
        switch (powerupType) {
            case PowerUp.EXTRA_LIFE:
                pp = inst(powerUp.life) as PowerUp; break;
            case PowerUp.SPEED:
                pp = inst(powerUp.speed) as PowerUp; break;
            case PowerUp.POWER:
                pp = inst(powerUp.power) as PowerUp; break;
            case PowerUp.PADDLE_GROW:
                pp = inst(powerUp.big) as PowerUp; break;
            case PowerUp.PADDLE_SHRINK:
                pp = inst(powerUp.small) as PowerUp; break;
            case PowerUp.MULTI_BALL:
                pp = inst(powerUp.multi) as PowerUp; break;
            case PowerUp.NONE: default:
                pp = null; break;
        }
    }

    Object inst (Object original) {
        return Instantiate(original, gameObject.transform.position, Quaternion.identity) as Object;
    }
}
