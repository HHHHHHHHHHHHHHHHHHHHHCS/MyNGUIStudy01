using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private List<ItemGrid> gridList;

    private void Awake()
    {
        Instance = this;
        gridList = new List<ItemGrid>();
        var grids = transform.GetComponentsInChildren<ItemGrid>();
        gridList.AddRange(grids);
    }

    public bool CheckPutItem(GameObject surface, out ItemGrid _grid)
    {
        _grid = surface.GetComponent<ItemGrid>();
        if (!_grid)
        {
            var item = surface.GetComponent<KnapsackItem>();
            if (item)
            {
                _grid = item.NowGrid;
            }
            if (!_grid)
            {
                return false;
            }
        }

        if (gridList.Contains(_grid))
        {
            return true;
        }
        return false;
    }

    public void PutItem(KnapsackItem item, ItemGrid itemGrid, ItemGrid surfaceGrid)
    {
        if (!surfaceGrid)
        {
            return;
        }

        KnapsackItem newItem = surfaceGrid.NowItem;

        if (!newItem)
        {
            surfaceGrid.PutItem(item);
        }
        else
        {
            if (newItem.ItemID == item.ItemID)
            {
                newItem.UpdateItemCount(item.ItemCount);
                Destroy(item.gameObject);
            }
            else
            {
                surfaceGrid.PutItem(item);
                itemGrid.PutItem(newItem);
            }

        }
    }
}
