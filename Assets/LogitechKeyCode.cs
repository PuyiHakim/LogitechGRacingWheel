using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public enum LogitechKeyCode
{

    #region
    //Firstindex 0 corresponds to the first controller connected, SecondIndex 1 to the second game contrroler
    FirstIndex = 0,
    SecondIndex = 1,
    #endregion

    //FOR G29 INPUTS
    #region
    Cross = 0,
    Square = 1,
    Circle = 2,
    Triangle = 3,
    #endregion

    #region
    //May be used for gears without Shifter or for indicators
    RIGHTBUMPER = 4,
    LEFTBUMPER = 5,
    #endregion


    R2 = 6,
    L2 = 7,
    SHARE = 8,
    OPTION = 9,
    R3 = 10,
    L3 = 11,

    #region
    // Logitech Shifter for G29 and G2920
    Shifter1 = 12,
    Shifter2 = 13,
    Shifter3 = 14,
    Shifter4 = 15,
    Shifter5 = 16,
    Shifter6 = 17,
    Shifter7 = 18,
    #endregion

    #region
    //may be used for volume
    LogiPlus = 19,
    LogiMinus = 20,
    #endregion


    #region
    // Combination of red and black button
    RedClockwise = 21,
    RedAntiClockWise = 22,
    ArrowButton = 23,
    #endregion

    PSButton = 24,

    #region
    //Directional PAd
    UPButton = 0,
    DOWNButton = 18000,
    LEFTButton = 27000,
    RIGHTButton = 9000,
    UP_LEFTButton = 31500,
    UP_RIGHTButton = 4500,
    DOWN_LEFTButton = 22500,
    DOWN_RIGHTButton = 13500,
    #endregion
};