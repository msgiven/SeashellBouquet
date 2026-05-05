using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Box : MonoBehaviour, IDropHandler
{
    [SerializeField] private RawImage rightSock;
    [SerializeField] GameEventSO putSock;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject go = eventData.pointerDrag;
        Sock sock = go.GetComponent<Sock>();
        Texture sockTex = sock.texture; 
        if (sockTex == rightSock.texture)
        {
            putSock.Raise();
            go.SetActive(false);
        }
    }
}
