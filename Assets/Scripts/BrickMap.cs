using UnityEngine;
using System.Collections;

public class BrickMap : MonoBehaviour {

    //public MultiBrick[][] bricks;
    public MultiBrick brickRef;
    public int[][] map = new int[10][];
    
    public const int BRICK_X = 0, 
                     BRICK_Y = 1, 
                     BRICK_TYPE = 2, 
                     BRICK_POWER = 3;
    
    public int BrickCount { get { return map.Length; } }
    public int index { get { return BrickCount - 1; } }
    
    // Use this for initialization
    void Start() {
        loadBricks();
        setBricks();
    }

    int[] BrickArray (int x, int y, string color = MultiBrick.RED, string powerUp = PowerUp.NONE) {
        return new int[4] { x, y, BT(color), BP(powerUp) };
    }
    void loadBricks() {
        //map[index] = BrickArray(10, 10, MultiBrick.RED, PowerUp.SPEED);
        map[index] = new int[4] { 10, 10, BT(MultiBrick.RED), BP(PowerUp.SPEED) };
        //map[index] = BrickArray(11, 11);
        //map[index] = BrickArray(12, 12, MultiBrick.GREEN, PowerUp.PADDLE_GROW);
        //map[index] = BrickArray(13, 13, MultiBrick.GREY);
    }

    void setBricks() {
        Debug.Log(map[0][0].ToString());
        //foreach (int[] brick in map) {
            //Vector3 pos = new Vector3();
            //pos.x = brick[BRICK_X];
            //pos.y = brick[BRICK_Y];

            //MultiBrick newBrick = Instantiate(brickRef, pos, Quaternion.identity) as MultiBrick;
            //newBrick.type = BT(brick[BRICK_TYPE]);
            //newBrick.powerupType = BP(brick[BRICK_POWER]);
        //}
    }
    // returns BrickType as string
    public string BT (int typeInt) {
        return typeInt == 1 ? MultiBrick.GREEN :
               typeInt == 2 ? MultiBrick.BLUE :
               typeInt == 3 ? MultiBrick.GREY : MultiBrick.RED;
    }
    // returns BrickPower as string
    public string BP (int powInt) {
        return powInt == 1 ? PowerUp.SPEED : 
               powInt == 2 ? PowerUp.POWER : 
               powInt == 3 ? PowerUp.PADDLE_GROW : 
               powInt == 4 ? PowerUp.PADDLE_SHRINK : 
               powInt == 5 ? PowerUp.MULTI_BALL : "";
    }
    // returns BrickType as int
    public int BT (string typeStr) {
        return typeStr == MultiBrick.GREEN ? 1 : 
               typeStr == MultiBrick.BLUE  ? 2 : 
               typeStr == MultiBrick.GREY  ? 3 : 0;
    }
    // returns BrickPower as int
    public int BP (string powStr) {
        return powStr == PowerUp.SPEED         ? 1 :
               powStr == PowerUp.POWER         ? 2 :
               powStr == PowerUp.PADDLE_GROW   ? 3 :
               powStr == PowerUp.PADDLE_SHRINK ? 4 :
               powStr == PowerUp.MULTI_BALL    ? 5 : 0;
    }
}
