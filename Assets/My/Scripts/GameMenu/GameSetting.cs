using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameGrade
{
    Esay,
    Normal,
    Diffculty,
}

public enum ControlType
{
    Keyboard,
    Touch,
    Mouse,
}



public class GameSetting : MonoBehaviour
{
    public static float volume = 1;
    public static GameGrade gameGrade = GameGrade.Esay;
    public static ControlType controlType = ControlType.Keyboard;
    public static bool isFullScreen = false;
}
