using UnityEngine;
using System.Collections;

public class MultiBrick : MonoBehaviour {

    public const string RED = "red", GREEN = "green", BLUE = "blue", GREY = "grey";

    [SerializeField]
    public string type = RED;
    public string powerupType;
    public Brick red, green, blue, grey;
    public PowerUp powerUp;

    public AudioClip CrackSound, BreakSound;

	// Use this for initialization
	void Start () {
        setBrickType();
	}
    void OnDestroy() {
        setPowerUpType();
        powerUp.gameObject.SetActive(true);
    }
    void setBrickType() {
        Brick bb = (type == RED)   ? inst(red)   as Brick :
                   (type == GREEN) ? inst(green) as Brick :
                   (type == BLUE)  ? inst(blue)  as Brick :
                   (type == GREY)  ? inst(grey)  as Brick : inst(red) as Brick;
    }
    void setPowerUpType() {
        powerUp.type = powerupType;
        PowerUp pp = (powerupType == PowerUp.EXTRA_LIFE)    ? inst(powerUp.life)  as PowerUp :
                     (powerupType == PowerUp.SPEED)         ? inst(powerUp.speed) as PowerUp :
                     (powerupType == PowerUp.POWER)         ? inst(powerUp.power) as PowerUp :
                     (powerupType == PowerUp.PADDLE_GROW)   ? inst(powerUp.big)   as PowerUp :
                     (powerupType == PowerUp.PADDLE_SHRINK) ? inst(powerUp.small) as PowerUp :
                     (powerupType == PowerUp.MULTI_BALL)    ? inst(powerUp.multi) as PowerUp : null;
    }
    Object inst (Object original) {
        return Instantiate(original, gameObject.transform.position, Quaternion.identity) as Object;
    }
}
