using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject drop = eventData.pointerDrag;
        InventoryItem invItem = drop.GetComponent<InventoryItem>();
        invItem.Parent = transform;
    }

    public void GetItem(Item item)
    {
        InventoryItem invItem = gameObject.AddComponent<InventoryItem>();
        invItem.Init(transform, item.image);
    }
}
