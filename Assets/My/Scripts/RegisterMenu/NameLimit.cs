using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NameLimit : MonoBehaviour
{
    private UIInput nameInput;

    private void Awake()
    {
        nameInput = GetComponent<UIInput>();
        EventDelegate.Add(nameInput.onSubmit, OnNameValueSubmit);
    }

    private void OnNameValueSubmit()
    {
        Regex regChina = new Regex("^[\u4e00-\u9fa5]+$");
        Regex regEnglish = new Regex("^[a-zA-Z]+$");
        string str = nameInput.value;
        if (regEnglish.IsMatch(str))
        {
            Debug.Log(str);
            Debug.Log("是英文");
        }
        else if (regChina.IsMatch(str))
        {
            Debug.Log("是中文");
        }
        else
        {
            Debug.Log("输入类型错误");
        }
    }
}
