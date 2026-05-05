using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RawImage image;
    private Transform parent;
    public Transform Parent {
        get => parent;
        set => parent = value;
    }

    private RectTransform rectTran;
    private Canvas canvas;
    private Vector2 offset;
    public void Init(Transform parent, Texture texture)
    {
        this.parent = parent;
        transform.SetParent(parent);
        image = gameObject.AddComponent<RawImage>();
        image.texture = texture;

        rectTran = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localCursorPos);

        offset = rectTran.localPosition - (Vector3)localCursorPos;

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localCursorPos);

        rectTran.localPosition = localCursorPos + offset;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
        image.raycastTarget = true;
    }
}
