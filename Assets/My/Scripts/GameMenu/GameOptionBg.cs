using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameGrade
{
    Esay,
    Normal,
    Hard,
}

public enum ControlType
{
    Keyboard,
    Touch,
    Mouse,
}



public class GameOptionBg : MonoBehaviour
{
    public float volume = 1;
    public GameGrade gameGrade = GameGrade.Esay;
    public ControlType controlType = ControlType.Keyboard;
    public bool isFullScreen = false;


    private UISlider volumeSlider;
    private UIPopupList gameGradeList;
    private UIPopupList gameControllerList;
    private UIToggle isFullScreenToggle;
    private UIButton completeOptionButton;


    private TweenPosition exitAnim_pos;
    private TweenScale exitAnim_sacle;


    private void Awake()
    {
        volumeSlider = transform.Find("VolumeLabel/VolumeSlider").GetComponent<UISlider>();
        gameGradeList = transform.Find("GameGradeLabel/GameGradeList").GetComponent<UIPopupList>();
        gameControllerList = transform.Find("GameControllerLabel/GameControllerList").GetComponent<UIPopupList>();
        isFullScreenToggle = transform.Find("IsFullScreenLabel/IsFullToggle").GetComponent<UIToggle>();
        completeOptionButton = transform.Find("CompleteOptionButton").GetComponent<UIButton>();

        exitAnim_pos = transform.GetComponent<TweenPosition>();
        exitAnim_sacle = transform.GetComponent<TweenScale>();

        EventDelegate.Add(volumeSlider.onChange, OnVolumeSliderChanged);
        EventDelegate.Add(gameGradeList.onChange, OnGameGradeChanged);
        EventDelegate.Add(gameControllerList.onChange, OnGameControlChanged);
        EventDelegate.Add(isFullScreenToggle.onChange, OnIsFullChanged);
        EventDelegate.Add(completeOptionButton.onClick, OnCompleteOptionClick);

    }

    private void OnVolumeSliderChanged()
    {
        Debug.Log("OnVolumeSliderChanged:" + UIProgressBar.current.value);
        volume = UIProgressBar.current.value;
    }

    private void OnGameGradeChanged()
    {
        Debug.Log("OnGameGradeChanged:" + UIPopupList.current.value);
        switch (UIPopupList.current.value)
        {
            case "简单":
                gameGrade = GameGrade.Esay;
                break;
            case "普通":
                gameGrade = GameGrade.Normal;
                break;
            case "困难":
                gameGrade = GameGrade.Hard;
                break;
            default:
                break;
        }
    }

    private void OnGameControlChanged()
    {
        Debug.Log("OnGameControlChanged:" + UIPopupList.current.value);
        switch (UIPopupList.current.value)
        {
            case "键盘":
                controlType = ControlType.Keyboard;
                break;
            case "触摸":
                controlType = ControlType.Touch;
                break;
            case "鼠标":
                controlType = ControlType.Mouse;
                break;
            default:
                break;
        }
    }

    private void OnIsFullChanged()
    {
        Debug.Log("OnIsFullChanged:" + UIToggle.current.value);
        isFullScreen = UIToggle.current.value;
    }

    private void OnCompleteOptionClick()
    {
        Debug.Log("OnCompleteOptionClick:Save");
        exitAnim_pos.PlayReverse();
        exitAnim_sacle.PlayReverse();
    }

    public void EnterAnim()
    {
        gameObject.SetActive(true);
        StartCoroutine(_EnterAnim());
    }

    private IEnumerator _EnterAnim()
    {
        yield return 0;
        exitAnim_pos.PlayForward();
        exitAnim_sacle.PlayForward();
    }
}
