using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MoveUIItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RawImage item;
    [SerializeField] private Canvas canvas;
    private Vector3 initPos;
    private RectTransform rectTran;
    private Vector2 offset;
    public RawImage Item {  get { return item; } }
    public bool isMoving {  get; private set; }
    public RectTransform RectTransform { get { return rectTran; } }
    private void Awake()
    {
        if (canvas == null)
            canvas = GetComponentInParent<Canvas>();
        if (item == null)
            item = GetComponent<RawImage>();
        rectTran = GetComponent<RectTransform>();
        initPos = transform.position;
    }
    private Vector2 GetCursorPosition(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localPoint);
        return localPoint;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMoving = true;
        offset = rectTran.localPosition - (Vector3)GetCursorPosition(eventData);
        item.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isMoving) return;

        rectTran.localPosition = offset + GetCursorPosition(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isMoving=false;
        item.raycastTarget = true;
        transform.position = initPos;
    }


}
