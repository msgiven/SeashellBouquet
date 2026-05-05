using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    List<Item> items;

    private void Start()
    {
        items = new List<Item>();   
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item.image.name);
    }

}
