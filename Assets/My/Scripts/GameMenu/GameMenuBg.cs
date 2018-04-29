using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuBg : MonoBehaviour
{
    private TweenPosition exitAnim;

    private void Awake()
    {
        var startButton = transform.Find("StartGameButton").gameObject;
        var optionButton = transform.Find("OptionButton").gameObject;
        var exitButton = transform.Find("ExitButton").gameObject;

        exitAnim = transform.GetComponent<TweenPosition>();

        UIEventListener.Get(optionButton).onClick += GotoGameOptionBg;
        exitAnim.AddOnFinished(() => { gameObject.SetActive(false); });
    }


    private void GotoGameOptionBg(GameObject newGo)
    {
        exitAnim.PlayForward();
        transform.parent.Find("GameOptionBg").GetComponent<GameOptionBg>()
            .EnterAnim();
    }
}
