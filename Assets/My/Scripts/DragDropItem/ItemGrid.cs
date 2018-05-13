using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{

    public KnapsackItem NowItem { get; private set; }


    public void PutItem(KnapsackItem item)
    {
        NowItem = item;
        item.NowGrid = this;
        var itemTS = item.transform;
        itemTS.SetParent(transform);
        itemTS.localPosition = Vector3.zero;
    }

    
}
