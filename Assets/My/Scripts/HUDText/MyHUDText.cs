using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHUDText : MonoBehaviour
{
    private HUDText hudText;

    private void Awake()
    {
        hudText = GetComponent<HUDText>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hudText.Add(-10, Color.red, 1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            hudText.Add(+10, Color.green, 1);
        }
    }
}
