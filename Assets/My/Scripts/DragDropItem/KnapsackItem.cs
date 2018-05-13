using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackItem : UIDragDropItem
{
    public string ItemID { get; private set; }
    public int ItemCount { get; private set; }
    public ItemGrid NowGrid { get; set; }

    private UISprite itemSprite;
    private UILabel itemCount;

    private readonly string[] itemIDData =
        {"Orc Armor - Boots","Orc Armor - Bracers","Orc Armor - Shoulders" };

    protected override void Awake()
    {
        base.Awake();
        ItemID = itemIDData[Random.Range(0, 3)];
        itemSprite = GetComponent<UISprite>();
        itemSprite.spriteName = ItemID;
        ItemCount = Random.Range(1, 5);
        itemCount = GetComponentInChildren<UILabel>();
        itemCount.text = ItemCount.ToString();
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        ItemGrid newItemGrid;
        bool isSucceed = GridManager.Instance.CheckPutItem(surface,out newItemGrid);
        if (isSucceed)
        {
            base.OnDragDropRelease(surface);
            GridManager.Instance.PutItem(this, NowGrid, newItemGrid);
        }
    }

    public void UpdateItemCount(int number)
    {
        ItemCount += number;
        itemCount.text = ItemCount.ToString();
    }
}
