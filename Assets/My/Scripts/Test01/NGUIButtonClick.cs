using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUIButtonClick : MonoBehaviour
{
    public GameObject labelButton;
    public GameObject spriteButton;
    public UIButton numberButton;


    private void Awake()
    {
        UIEventListener.Get(labelButton).onClick = go => { Debug.Log("Click:"+go); };
        UIEventListener.Get(spriteButton).onClick =go => { Debug.Log("Click:" + go); };
        //numberButton.SetState(UIButtonColor.State.Disabled, true);
        //numberButton.state = UIButtonColor.State.Disabled;
        numberButton.GetComponent<BoxCollider>().enabled = false;
    }
}
