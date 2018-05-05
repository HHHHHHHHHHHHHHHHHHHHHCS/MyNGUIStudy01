using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeLimit : MonoBehaviour
{
    private UIInput ageInput;

    private void Awake()
    {
        ageInput = GetComponent<UIInput>();
        EventDelegate.Add(ageInput.onSubmit, OnAgeValueSubmit);
    }

    private void OnAgeValueSubmit()
    {
        string val = ageInput.value;
        int age = int.Parse(val);

        age = Mathf.Clamp(age, 18, 120);
        ageInput.value = age.ToString();
    }
}
