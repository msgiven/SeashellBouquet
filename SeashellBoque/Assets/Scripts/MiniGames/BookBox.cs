using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookBox : MiniGameBase, IDropHandler
{
    [SerializeField] private RawImage[] rightBookComb;
    private int bookIndex = 0;

    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject go = eventData.pointerDrag.gameObject;
        MoveUIItem curBook = go.GetComponent<MoveUIItem>();

        if(curBook.Item.texture == rightBookComb[bookIndex].texture)
        {
            bookIndex++;
            go.SetActive(false);
        }
        if (bookIndex == rightBookComb.Length - 1) seashell.interactable = true;
    }

}
