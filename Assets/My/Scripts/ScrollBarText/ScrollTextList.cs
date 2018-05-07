using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTextList : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.GetComponent<UITextList>()
                .Add( Random.Range(0, 123456789).ToString());
        }
    }
}
