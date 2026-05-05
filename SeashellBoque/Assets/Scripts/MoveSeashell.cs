using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSeashell : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RawImage posImage;
    [SerializeField] private GameEventSO putSeashell;
    [SerializeField] private Canvas canvas;
    RectTransform rightTran;
    private RectTransform rectTran;
    private bool isMoving;
    private bool isOnRightPlace;
    private Vector2 offset;
    private void Start()
    {
        rightTran = posImage.GetComponent<RectTransform>();
        rectTran = GetComponent<RectTransform>();
        if (canvas == null) canvas = GetComponentInParent<Canvas>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isMoving = true;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localPos);
        offset = rectTran.localPosition - (Vector3)localPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isMoving || isOnRightPlace) return;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localPos);
        rectTran.localPosition = localPos + offset;

        if (Vector3.Distance(rightTran.localPosition, rectTran.localPosition) <= 3.0f)
        {
            rectTran = rightTran;
            posImage.gameObject.SetActive(false);
            isOnRightPlace = true;
            putSeashell.Raise();
        }
        else
        {
            Debug.Log(Vector3.Distance(rightTran.localPosition, rectTran.localPosition));
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isMoving=false;
    }
}
