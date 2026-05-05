using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public void AddItem(Item item)
    {
        Transform place = GetFreePlace();
        if (place)
        {
            InventorySlot slot = GetFreePlace().GetComponent<InventorySlot>();
            slot.GetItem(item);
        }
    }

    private Transform GetFreePlace()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }
}
