using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChatInput : MonoBehaviour
{
    [SerializeField]
    private UITextList textList;

    private UIInput uiInput;

    private void Awake()
    {
        uiInput = GetComponent<UIInput>();
        //UIEventListener.Get(gameObject).onSubmit += OnChatSubmit;
        EventDelegate.Add(uiInput.onSubmit, OnChatSubmit);
    }


    private void OnChatSubmit()
    {
        string chat = uiInput.value;
        textList.Add(chat);
        uiInput.value = "";
    }
}
