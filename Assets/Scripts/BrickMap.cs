using UnityEngine;
using System.Collections;

public class BrickMap : MonoBehaviour {
    
    public MultiBrick brickRef;
    public int[][][] map;
    
    int idx { get { return LevelManager.instance.currentLevel - 1; } }

    const int numLevels = 4;
    static int numberOfLevels { get { return numLevels; } }

    public const int BRICK_X = 0, 
                     BRICK_Y = 1, 
                     BRICK_TYPE = 2, 
                     BRICK_POWER = 3;
    
    // WARNING!: using this getter increments its value
    // int _brk = -1; int brk { get { _brk++; return _brk; } }
    
    // Use this for initialization
    void Start() {
        LevelManager.instance.levels = numLevels;
        loadBricks();   // Populates map array
        setBricks();    // Instantiates brick objects from map array
    }

    // Creates and formats brick data for the map array
    int[] Br (int x, int y, string color = MultiBrick.RED, string powerUp = PowerUp.NONE) {
        return new int[4] { x, y, BT(color), BP(powerUp) };
    }
    void loadBricks() {        
        // Initialize map array
        map = new int[numLevels][][];
        //map[0] = new int[98][] { Br(1, 22), Br(8, 22, MultiBrick.GREEN), Br(15, 22), Br(2, 21), Br(7, 21), Br(9, 21), Br(14, 21), Br(3, 20, MultiBrick.BLUE), Br(6, 20), Br(10, 20), Br(13, 20, MultiBrick.BLUE), Br(4, 19), Br(5, 19), Br(8, 19, MultiBrick.GREY), Br(11, 19), Br(12, 19), Br(4, 18), Br(5, 18, MultiBrick.GREEN), Br(8, 18), Br(11, 18, MultiBrick.GREEN), Br(12, 18), Br(3, 17), Br(6, 17), Br(10, 17), Br(13, 17), Br(2, 16), Br(7, 16), Br(9, 16), Br(14, 16), Br(1, 15, MultiBrick.GREEN), Br(4, 15, MultiBrick.GREY), Br(5, 15, MultiBrick.GREY), Br(8, 15, MultiBrick.BLUE), Br(11, 15, MultiBrick.GREY), Br(12, 15, MultiBrick.GREY), Br(15, 15, MultiBrick.GREEN), Br(2, 14), Br(7, 14), Br(9, 14), Br(14, 14), Br(3, 13, MultiBrick.GREEN), Br(6, 13), Br(10, 13), Br(13, 13, MultiBrick.GREEN), Br(4, 12), Br(5, 12, MultiBrick.BLUE), Br(8, 12, MultiBrick.GREEN), Br(11, 12, MultiBrick.BLUE), Br(12, 12), Br(4, 11), Br(5, 11, MultiBrick.BLUE), Br(8, 11, MultiBrick.GREEN), Br(11, 11, MultiBrick.BLUE), Br(12, 11), Br(3, 12, MultiBrick.GREEN), Br(6, 12), Br(10, 12), Br(13, 12, MultiBrick.GREEN), Br(2, 10), Br(7, 10), Br(9, 10), Br(14, 10), Br(1, 9, MultiBrick.GREEN), Br(4, 9, MultiBrick.GREY), Br(5, 9, MultiBrick.GREY), Br(8, 9, MultiBrick.BLUE), Br(11, 9, MultiBrick.GREY), Br(12, 9, MultiBrick.GREY), Br(15, 9, MultiBrick.GREEN), Br(2, 8), Br(7, 8), Br(9, 8), Br(14, 8), Br(3, 7), Br(6, 7), Br(10, 7), Br(13, 7), Br(4, 6), Br(5, 6, MultiBrick.GREEN), Br(8, 6), Br(11, 6, MultiBrick.GREEN), Br(12, 6), Br(4, 5), Br(5, 5), Br(8, 5, MultiBrick.GREY), Br(11, 5), Br(12, 5), Br(3, 4, MultiBrick.BLUE), Br(6, 4), Br(10, 4), Br(13, 4, MultiBrick.BLUE), Br(2, 3), Br(7, 3), Br(9, 3), Br(14, 3), Br(1, 2), Br(8, 2, MultiBrick.GREEN), Br(15, 2), };
        
        map[0] = new int[39][] {
            Br(2, 15), Br(3, 15), Br(4, 15), Br(5, 15), Br(6, 15), Br(7, 15, MultiBrick.GREEN), Br(8, 15, MultiBrick.GREEN), Br(9, 15, MultiBrick.GREEN), Br(10, 15), Br(11, 15), Br(12, 15), Br(13, 15), Br(14, 15),
            Br(2, 14), Br(3, 14), Br(4, 14), Br(5, 14), Br(6, 14), Br(7, 14),                   Br(8, 14),                   Br(9, 14),                   Br(10, 14), Br(11, 14), Br(12, 14), Br(13, 14), Br(14, 14),
            Br(2, 13), Br(3, 13), Br(4, 13), Br(5, 13), Br(6, 13), Br(7, 13),                   Br(8, 13),                   Br(9, 13),                   Br(10, 13), Br(11, 13), Br(12, 13), Br(13, 13), Br(14, 13)
        };
        map[1] = new int[55][] {
            Br(3, 19, MultiBrick.BLUE), Br(4, 19, MultiBrick.BLUE), Br(11, 19, MultiBrick.BLUE), Br(12, 19, MultiBrick.BLUE),
            Br(3, 18, MultiBrick.BLUE), Br(4, 18, MultiBrick.BLUE), Br(5, 18, MultiBrick.BLUE), Br(11, 18, MultiBrick.BLUE), Br(12, 18, MultiBrick.BLUE), Br(13, 18, MultiBrick.BLUE),
            Br(3, 14, MultiBrick.GREEN), Br(4, 14, MultiBrick.GREEN), Br(5, 14, MultiBrick.GREEN), Br(6, 14, MultiBrick.GREEN),
            Br(9, 14, MultiBrick.GREEN), Br(10, 14, MultiBrick.GREEN), Br(11, 14, MultiBrick.GREEN), Br(12, 14, MultiBrick.GREEN),
            Br(2, 13, MultiBrick.GREEN), Br(3, 13, MultiBrick.GREEN), Br(4, 13, MultiBrick.GREEN), Br(5, 13, MultiBrick.GREEN), Br(6, 13, MultiBrick.GREEN), Br(7, 13, MultiBrick.GREEN), Br(8, 13, MultiBrick.GREEN),
            Br(9, 13, MultiBrick.GREEN), Br(10, 13, MultiBrick.GREEN), Br(11, 13, MultiBrick.GREEN), Br(12, 13, MultiBrick.GREEN), Br(13, 13, MultiBrick.GREEN), Br(14, 13, MultiBrick.GREEN),
            Br(4, 12), Br(5, 12), Br(7, 12), Br(8, 12), Br(10, 12), Br(11, 12), Br(13, 12), Br(14, 12),
            Br(2, 10), Br(3, 10), Br(4, 10), Br(5, 10), Br(6, 10), Br(7, 10), Br(8, 10), Br(9, 10), Br(10, 10), Br(11, 10), Br(12, 10), Br(13, 10),
            Br(3, 9), Br(6, 9), Br(9, 9), Br(12, 9)
        };
        map[2] = new int[61][] {
            Br(2, 20, MultiBrick.BLUE), Br(8, 20, MultiBrick.BLUE), Br(14, 20, MultiBrick.BLUE),
            Br(1, 19, MultiBrick.BLUE), Br(2, 19, MultiBrick.BLUE), Br(7, 19, MultiBrick.BLUE), Br(8, 19, MultiBrick.BLUE), Br(13, 19, MultiBrick.BLUE), Br(14, 19, MultiBrick.BLUE),
            Br(1, 18, MultiBrick.BLUE), Br(2, 18, MultiBrick.BLUE), Br(3, 18, MultiBrick.BLUE), Br(5, 18, MultiBrick.GREY), Br(7, 18, MultiBrick.BLUE), Br(8, 18, MultiBrick.BLUE),
            Br(9, 18, MultiBrick.BLUE), Br(11, 18, MultiBrick.GREY), Br(13, 18, MultiBrick.BLUE), Br(14, 18, MultiBrick.BLUE), Br(15, 18, MultiBrick.BLUE),
            Br(5, 15), Br(11, 15),
            Br(4, 14), Br(5, 14), Br(10, 14), Br(11, 14),
            Br(5, 13), Br(11, 13),
            Br(2, 11, MultiBrick.BLUE), Br(8, 11, MultiBrick.BLUE), Br(14, 11, MultiBrick.BLUE),
            Br(1, 12, MultiBrick.GREEN), Br(2, 12, MultiBrick.GREEN), Br(7, 12, MultiBrick.GREEN), Br(8, 12, MultiBrick.GREEN), Br(13, 12, MultiBrick.GREEN), Br(14, 12, MultiBrick.GREEN),
            Br(1, 10, MultiBrick.GREEN), Br(2, 10, MultiBrick.GREEN), Br(3, 10, MultiBrick.GREEN), Br(7, 10, MultiBrick.GREEN), Br(8, 10, MultiBrick.GREEN),
            Br(9, 10, MultiBrick.GREEN), Br(13, 10, MultiBrick.GREEN), Br(14, 10, MultiBrick.GREEN), Br(15, 10, MultiBrick.GREEN),
            Br(1, 9), Br(2, 9), Br(7, 9), Br(8, 9), Br(13, 9), Br(14, 9),
            Br(1, 8), Br(2, 8), Br(3, 8), Br(7, 8), Br(8, 8), Br(9, 8), Br(13, 8), Br(14, 8), Br(15, 8)
        };
        map[3] = new int[70][] {
            Br(4, 20), Br(5, 20, MultiBrick.GREEN), Br(6, 20, MultiBrick.BLUE), Br(7, 20, MultiBrick.BLUE), Br(8, 20, MultiBrick.BLUE),
            Br(9, 20, MultiBrick.BLUE), Br(10, 20, MultiBrick.BLUE), Br(11, 20, MultiBrick.GREEN), Br(12, 20),
            Br(4, 19), Br(5, 19, MultiBrick.GREEN), Br(6, 19, MultiBrick.BLUE), Br(10, 19, MultiBrick.BLUE), Br(11, 19, MultiBrick.GREEN), Br(12, 19),
            Br(4, 18), Br(5, 18, MultiBrick.GREEN), Br(6, 18, MultiBrick.BLUE), Br(10, 18, MultiBrick.BLUE), Br(11, 18, MultiBrick.GREEN), Br(12, 18),
            Br(4, 17), Br(5, 17, MultiBrick.GREEN), Br(6, 17, MultiBrick.BLUE), Br(8, 17, MultiBrick.GREEN), Br(10, 17, MultiBrick.BLUE), Br(11, 17, MultiBrick.GREEN), Br(12, 17),
            Br(4, 16), Br(5, 16, MultiBrick.GREEN), Br(6, 16, MultiBrick.BLUE), Br(8, 16, MultiBrick.GREEN), Br(10, 16, MultiBrick.BLUE), Br(11, 16, MultiBrick.GREEN), Br(12, 16),
            Br(4, 15), Br(5, 15, MultiBrick.GREEN), Br(6, 15, MultiBrick.GREY), Br(8, 15, MultiBrick.GREEN), Br(10, 15, MultiBrick.GREY), Br(11, 15, MultiBrick.GREEN), Br(12, 15),
            Br(4, 14), Br(5, 14, MultiBrick.GREEN), Br(6, 14, MultiBrick.GREY), Br(8, 14, MultiBrick.GREEN), Br(10, 14, MultiBrick.GREY), Br(11, 14, MultiBrick.GREEN), Br(12, 14),
            Br(4, 13), Br(5, 13, MultiBrick.GREEN), Br(6, 13, MultiBrick.GREY), Br(8, 13, MultiBrick.GREEN), Br(10, 13, MultiBrick.GREY), Br(11, 13, MultiBrick.GREEN), Br(12, 13),
            Br(4, 12), Br(5, 12, MultiBrick.GREY), Br(6, 12, MultiBrick.GREY), Br(8, 12, MultiBrick.GREEN), Br(10, 12, MultiBrick.GREY), Br(11, 12, MultiBrick.GREY), Br(12, 12),
            Br(4, 11), Br(5, 11, MultiBrick.GREY), Br(6, 11, MultiBrick.GREY), Br(8, 11, MultiBrick.GREEN), Br(10, 11, MultiBrick.GREY), Br(11, 11, MultiBrick.GREY), Br(12, 11)
        };//*/
    }

    // Instantiation Functions

    void setBricks() { foreach (int[] thisBrick in map[idx]) { makeBrick(thisBrick); } }    
    Vector3 brickPos (int[] bS) { return new Vector3 ( (float)bS[BRICK_X]/1, (float)bS[BRICK_Y]/2.75f + 1.5f); }
    void makeBrick (int[] brickStats) {
        MultiBrick newBrick = Instantiate(brickRef, brickPos(brickStats), Quaternion.identity) as MultiBrick;
        newBrick.type = BT(brickStats[BRICK_TYPE]);
        newBrick.powerupType = BP(brickStats[BRICK_POWER]);
    }

    // Conversion Functions

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
