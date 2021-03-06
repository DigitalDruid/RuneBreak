﻿using UnityEngine;
using System.Collections;

public static class ProgressManager {

    /* CODE AUTO GENERATED BY LEVEL CREATOR SHEET
    *      generated on: [TODAY'S DATE]
    */
    // INITIALIZE MAP ARRAY 
    public static int[][][] levelMap = new int[4][][] {
        /* LEVEL 1 CODE */					
            new int[98][] { Br(4, 26), Br(6, 26), Br(8, 26), Br(10, 26, MultiBrick.GREEN, PowerUp.BIG), Br(12, 26, MultiBrick.GREEN), Br(14, 26), Br(16, 26), Br(18, 26), Br(20, 26, MultiBrick.GREEN, PowerUp.SPEED), Br(22, 26, MultiBrick.GREEN), Br(24, 26), Br(26, 26), Br(28, 26), Br(4, 22), Br(6, 22), Br(8, 22), Br(10, 22), Br(12, 22), Br(14, 22), Br(16, 22), Br(18, 22), Br(20, 22), Br(22, 22), Br(24, 22), Br(26, 22), Br(28, 22), Br(4, 21), Br(28, 21), Br(4, 20), Br(28, 20), Br(4, 19), Br(8, 19), Br(10, 19), Br(12, 19), Br(14, 19), Br(16, 19), Br(18, 19), Br(20, 19), Br(22, 19), Br(24, 19), Br(28, 19), Br(4, 18), Br(8, 18), Br(24, 18), Br(28, 18), Br(4, 17), Br(8, 17), Br(14, 17, MultiBrick.GREEN), Br(16, 17, MultiBrick.GREEN), Br(18, 17, MultiBrick.GREEN), Br(24, 17), Br(28, 17), Br(4, 16), Br(8, 16), Br(14, 16, MultiBrick.GREEN), Br(16, 16, MultiBrick.RED, PowerUp.MULTI), Br(18, 16, MultiBrick.GREEN), Br(24, 16), Br(28, 16), Br(4, 15), Br(8, 15), Br(14, 15, MultiBrick.GREEN), Br(16, 15, MultiBrick.GREEN), Br(18, 15, MultiBrick.GREEN), Br(24, 15), Br(28, 15), Br(4, 14), Br(8, 14), Br(24, 14), Br(28, 14), Br(4, 13), Br(8, 13), Br(10, 13), Br(12, 13), Br(14, 13), Br(16, 13), Br(18, 13), Br(20, 13), Br(22, 13), Br(24, 13), Br(28, 13), Br(4, 12), Br(28, 12), Br(4, 11), Br(28, 11), Br(4, 10), Br(6, 10), Br(8, 10), Br(10, 10), Br(12, 10), Br(14, 10), Br(16, 10), Br(18, 10), Br(20, 10), Br(22, 10), Br(24, 10), Br(26, 10), Br(28, 10), },
        /* LEVEL 2 CODE */
            new int[159][] { Br(4, 27), Br(28, 27), Br(4, 26), Br(6, 26, MultiBrick.GREEN), Br(26, 26, MultiBrick.GREEN), Br(28, 26), Br(4, 25), Br(6, 25, MultiBrick.GREEN, PowerUp.MULTI), Br(8, 25, MultiBrick.BLUE), Br(24, 25, MultiBrick.BLUE, PowerUp.SMALL), Br(26, 25, MultiBrick.GREEN), Br(28, 25), Br(4, 24), Br(6, 24), Br(8, 24, MultiBrick.BLUE), Br(10, 24, MultiBrick.BLUE), Br(22, 24, MultiBrick.BLUE), Br(24, 24, MultiBrick.BLUE), Br(26, 24), Br(28, 24), Br(4, 23), Br(6, 23), Br(8, 23, MultiBrick.GREEN), Br(10, 23, MultiBrick.BLUE, PowerUp.SPEED), Br(12, 23, MultiBrick.BLUE), Br(20, 23, MultiBrick.BLUE, PowerUp.BIG), Br(22, 23, MultiBrick.BLUE), Br(24, 23, MultiBrick.GREEN), Br(26, 23), Br(28, 23), Br(4, 22), Br(6, 22), Br(8, 22, MultiBrick.GREEN), Br(10, 22, MultiBrick.GREEN), Br(12, 22, MultiBrick.BLUE), Br(14, 22, MultiBrick.BLUE), Br(18, 22, MultiBrick.BLUE), Br(20, 22, MultiBrick.BLUE), Br(22, 22, MultiBrick.GREEN), Br(24, 22, MultiBrick.GREEN), Br(26, 22), Br(28, 22), Br(4, 21), Br(6, 21), Br(8, 21), Br(10, 21, MultiBrick.GREEN), Br(12, 21, MultiBrick.GREEN), Br(14, 21, MultiBrick.BLUE), Br(16, 21, MultiBrick.BLUE, PowerUp.POWER), Br(18, 21, MultiBrick.BLUE), Br(20, 21, MultiBrick.GREEN), Br(22, 21, MultiBrick.GREEN), Br(24, 21), Br(26, 21), Br(28, 21), Br(4, 20), Br(6, 20), Br(8, 20), Br(10, 20), Br(12, 20, MultiBrick.GREEN), Br(14, 20, MultiBrick.GREEN), Br(16, 20, MultiBrick.BLUE), Br(18, 20, MultiBrick.GREEN), Br(20, 20, MultiBrick.GREEN), Br(22, 20), Br(24, 20), Br(26, 20), Br(28, 20), Br(4, 19), Br(6, 19), Br(8, 19), Br(10, 19), Br(12, 19), Br(14, 19, MultiBrick.GREEN), Br(16, 19, MultiBrick.GREEN, PowerUp.LIFE), Br(18, 19, MultiBrick.GREEN), Br(20, 19), Br(22, 19), Br(24, 19), Br(26, 19), Br(28, 19), Br(4, 18), Br(6, 18), Br(8, 18), Br(10, 18), Br(12, 18), Br(14, 18), Br(16, 18, MultiBrick.GREEN), Br(18, 18), Br(20, 18), Br(22, 18), Br(24, 18), Br(26, 18), Br(28, 18), Br(4, 17), Br(6, 17), Br(8, 17), Br(10, 17), Br(12, 17), Br(14, 17), Br(16, 17), Br(18, 17), Br(20, 17), Br(22, 17), Br(24, 17), Br(26, 17), Br(28, 17), Br(4, 16), Br(6, 16), Br(8, 16), Br(10, 16), Br(12, 16), Br(14, 16), Br(16, 16), Br(18, 16), Br(20, 16), Br(22, 16), Br(24, 16), Br(26, 16), Br(28, 16), Br(4, 15), Br(6, 15), Br(8, 15), Br(10, 15), Br(12, 15), Br(14, 15), Br(16, 15), Br(18, 15), Br(20, 15), Br(22, 15), Br(24, 15), Br(26, 15), Br(28, 15), Br(4, 14), Br(6, 14), Br(8, 14), Br(10, 14), Br(12, 14), Br(14, 14), Br(16, 14), Br(18, 14), Br(20, 14), Br(22, 14), Br(24, 14), Br(26, 14), Br(28, 14), Br(4, 13), Br(6, 13), Br(8, 13), Br(10, 13), Br(12, 13), Br(14, 13), Br(16, 13), Br(18, 13), Br(20, 13), Br(22, 13), Br(24, 13), Br(26, 13), Br(28, 13), },
        /* LEVEL 3 CODE */
            new int[74][] { Br(8, 27, MultiBrick.BLUE, PowerUp.SMALL), Br(10, 27, MultiBrick.BLUE), Br(22, 27, MultiBrick.BLUE), Br(24, 27, MultiBrick.BLUE, PowerUp.BIG), Br(6, 26, MultiBrick.BLUE), Br(8, 26, MultiBrick.BLUE), Br(24, 26, MultiBrick.BLUE), Br(26, 26, MultiBrick.BLUE), Br(6, 25, MultiBrick.GREEN), Br(26, 25, MultiBrick.GREEN), Br(4, 24, MultiBrick.GREEN, PowerUp.MULTI), Br(6, 24, MultiBrick.GREEN), Br(14, 24), Br(16, 24), Br(18, 24), Br(26, 24, MultiBrick.GREEN, PowerUp.MULTI), Br(28, 24, MultiBrick.GREEN), Br(4, 23, MultiBrick.GREEN), Br(14, 23, MultiBrick.GREEN), Br(16, 23, MultiBrick.BLUE, PowerUp.SPEED), Br(18, 23, MultiBrick.GREEN), Br(28, 23, MultiBrick.GREEN), Br(4, 22), Br(14, 22, MultiBrick.GREEN), Br(16, 22, MultiBrick.BLUE, PowerUp.POWER), Br(18, 22, MultiBrick.GREEN), Br(28, 22), Br(4, 21), Br(14, 21), Br(16, 21), Br(18, 21), Br(28, 21), Br(4, 20), Br(28, 20), Br(4, 19), Br(6, 19), Br(12, 19, MultiBrick.GREY), Br(14, 19, MultiBrick.GREY), Br(16, 19, MultiBrick.GREY), Br(18, 19, MultiBrick.GREY), Br(20, 19, MultiBrick.GREY), Br(26, 19), Br(28, 19), Br(6, 18), Br(8, 18), Br(24, 18), Br(26, 18), Br(8, 17), Br(24, 17), Br(6, 15), Br(8, 15), Br(24, 15), Br(26, 15), Br(4, 14), Br(6, 14), Br(26, 14), Br(28, 14), Br(4, 13), Br(28, 13), Br(4, 12), Br(12, 12, MultiBrick.GREY), Br(14, 12, MultiBrick.GREY), Br(16, 12, MultiBrick.GREY), Br(18, 12, MultiBrick.GREY), Br(20, 12, MultiBrick.GREY), Br(28, 12), Br(4, 11), Br(6, 11), Br(26, 11), Br(28, 11), Br(6, 10), Br(8, 10), Br(24, 10), Br(26, 10), },
        /* LEVEL 4 CODE */					
            new int[81][] { Br(4, 26, MultiBrick.BLUE, PowerUp.BIG), Br(28, 26, MultiBrick.BLUE, PowerUp.SMALL), Br(4, 25, MultiBrick.BLUE), Br(8, 25, MultiBrick.GREY), Br(10, 25, MultiBrick.BLUE, PowerUp.LIFE), Br(12, 25, MultiBrick.GREY), Br(16, 25, MultiBrick.RED, PowerUp.MULTI), Br(20, 25, MultiBrick.GREY), Br(22, 25, MultiBrick.BLUE, PowerUp.POWER), Br(24, 25, MultiBrick.GREY), Br(28, 25, MultiBrick.BLUE), Br(4, 24, MultiBrick.BLUE), Br(8, 24, MultiBrick.GREY), Br(10, 24, MultiBrick.GREY), Br(12, 24, MultiBrick.GREY), Br(16, 24), Br(20, 24, MultiBrick.GREY), Br(22, 24, MultiBrick.GREY), Br(24, 24, MultiBrick.GREY), Br(28, 24, MultiBrick.BLUE), Br(4, 23, MultiBrick.BLUE), Br(6, 23, MultiBrick.GREEN), Br(16, 23), Br(26, 23, MultiBrick.GREEN), Br(28, 23, MultiBrick.BLUE), Br(6, 22, MultiBrick.GREEN), Br(16, 22), Br(26, 22, MultiBrick.GREEN), Br(6, 21, MultiBrick.GREEN), Br(14, 21), Br(16, 21), Br(18, 21), Br(26, 21, MultiBrick.GREEN), Br(6, 20, MultiBrick.GREEN), Br(14, 20), Br(16, 20), Br(18, 20), Br(26, 20, MultiBrick.GREEN), Br(16, 19), Br(8, 16, MultiBrick.GREY), Br(10, 16, MultiBrick.GREEN), Br(12, 16, MultiBrick.GREEN), Br(14, 16, MultiBrick.GREEN), Br(16, 16, MultiBrick.GREEN), Br(18, 16, MultiBrick.GREEN), Br(20, 16, MultiBrick.GREEN), Br(22, 16, MultiBrick.GREEN), Br(24, 16, MultiBrick.GREY), Br(8, 15, MultiBrick.GREY), Br(10, 15, MultiBrick.GREY), Br(12, 15, MultiBrick.BLUE, PowerUp.MULTI), Br(14, 15, MultiBrick.GREEN), Br(16, 15, MultiBrick.GREEN), Br(18, 15, MultiBrick.GREEN), Br(20, 15, MultiBrick.BLUE, PowerUp.SPEED), Br(22, 15, MultiBrick.GREY), Br(24, 15, MultiBrick.GREY), Br(10, 14, MultiBrick.GREY), Br(12, 14, MultiBrick.GREY), Br(14, 14, MultiBrick.GREEN), Br(16, 14, MultiBrick.BLUE), Br(18, 14, MultiBrick.GREEN), Br(20, 14, MultiBrick.GREY), Br(22, 14, MultiBrick.GREY), Br(12, 13, MultiBrick.GREY), Br(14, 13, MultiBrick.GREY), Br(16, 13, MultiBrick.GREY), Br(18, 13, MultiBrick.GREY), Br(20, 13, MultiBrick.GREY), Br(12, 10), Br(20, 10), Br(10, 9), Br(12, 9), Br(20, 9), Br(22, 9), Br(10, 8), Br(12, 8), Br(20, 8), Br(22, 8), Br(10, 7), Br(22, 7), },
        };
    /* END AUTO GENERATED CODE */					
					

    public const string GAME_PROGRESS = "GameProgress";
    public static string LEVEL_SCORE (int level) { return "Level_" + level + "_Score"; }
    public static string LEVEL_HIGHSCORE (int level) { return "Level_" + level + "_HighScore"; }

    public static bool isSet {
        get { return PlayerPrefs.HasKey(GAME_PROGRESS); }
    }
    public static int completedLevels {
        get { 
            if (!isSet) PlayerPrefs.SetInt(GAME_PROGRESS, 0);
            return PlayerPrefs.GetInt(GAME_PROGRESS);
        }
        set { PlayerPrefs.SetInt(GAME_PROGRESS, value); }
    }
    public static int getScore (int level, bool highScore = false) {
        string STRING = "Level_" + level;
        STRING += (highScore) ? "_HighScore" : "_Score";
        return PlayerPrefs.GetInt(STRING);
    }
    public static void setScore (int level, int score) {
        PlayerPrefs.SetInt("Level_" + level + "_Score", score);
        if(score > getScore(level)) PlayerPrefs.SetInt("Level_" + level + "_HighScore", score);
    }
    public static int getTotalScore {
        get {
            int total = 0;
            for (int i = 0; i <= levelMap.Length; i++) { total += getScore(i + 1); }
            return total;
        }
    }
    //
    // Summary:
    //     ///
    //     Creates and formats brick data for the map array
    //     ///
    //
    // Parameters:
    //   x:
    //
    //   y:
    //
    //   color:
    //
    //   powerUp:
    public static int[] Br(int x, int y, string color = MultiBrick.RED, string powerUp = PowerUp.NONE) {
        return new int[4] { x, y, BT(color), BP(powerUp) };
    }
    //
    // Summary:
    //     ///
    //     Returns BrickType as int
    //     ///
    //
    // Parameters:
    //   typeStr:
    static int BT(string typeStr) {
        return typeStr == MultiBrick.GREEN ? 1 :
               typeStr == MultiBrick.BLUE ? 2 :
               typeStr == MultiBrick.GREY ? 3 : 0;
    }
    //
    // Summary:
    //     ///
    //     Returns BrickPower as integer
    //     ///
    //
    // Parameters:
    //   powStr:
    static int BP(string powStr) {
        return powStr == PowerUp.SPEED ? 1 :
               powStr == PowerUp.POWER ? 2 :
               powStr == PowerUp.PADDLE_GROW ? 3 :
               powStr == PowerUp.PADDLE_SHRINK ? 4 :
               powStr == PowerUp.MULTI_BALL ? 5 : 0;
    }
}
