using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDragDropItem : UIDragDropItem
{
    protected override void OnDragDropRelease(GameObject surface)
    {
        Debug.Log(surface);
        base.OnDragDropRelease(surface);
    }
}
