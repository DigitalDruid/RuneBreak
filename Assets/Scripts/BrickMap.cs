using UnityEngine;
using System.Collections;

public class BrickMap : MonoBehaviour {

    //public MultiBrick[][] bricks;
    public MultiBrick brickRef;
    public int[][][] map;

    int level { get { return LevelManager.currentLevel; } }
    int idx { get { return level - 1; } }

    public const int BRICK_X = 0, 
                     BRICK_Y = 1, 
                     BRICK_TYPE = 2, 
                     BRICK_POWER = 3;
    
    //public int BrickCount { get { return map[idx].Length; } }
    
    // WARNING!: using this getter increments its value
    int _brk = -1; int brk { get { _brk++; return _brk; } }
    
    // Use this for initialization
    void Start() {
        map = new int[1][][];
        loadBricks();
        setBricks();
    }

    int[] BrickArray (int x, int y, string color = MultiBrick.RED, string powerUp = PowerUp.NONE) {
        return new int[4] { x, y, BT(color), BP(powerUp) };
    }
    void loadBricks() {
        const int bricksInLevelOne = 4;
        map[0] = new int[bricksInLevelOne][] {
            // { x, y, color, powerup }
            BrickArray( 10, 10, MultiBrick.RED,   PowerUp.SPEED),
            BrickArray(  5,  5, MultiBrick.GREEN),
            BrickArray( 11, 11), 
            BrickArray( 0, 0, MultiBrick.GREY)
        };
    }

    void setBricks() {
        foreach (int[][] thisLevel in map) {
            foreach (int[] thisBrick in thisLevel) { makeBrick(thisBrick); }
        }
    }
    void makeBrick (int[] brickStats) {
        MultiBrick newBrick = Instantiate(brickRef, new Vector3(brickStats[BRICK_X], brickStats[BRICK_Y]), Quaternion.identity) as MultiBrick;
        newBrick.type = BT(brickStats[BRICK_TYPE]);
        newBrick.powerupType = BP(brickStats[BRICK_POWER]);
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
