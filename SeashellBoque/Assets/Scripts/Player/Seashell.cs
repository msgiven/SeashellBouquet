using UnityEngine;

public class Seashell : MonoBehaviour, IInteractable
{
    [SerializeField] private Item item;
    public Item Item { get { return item; } }

    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        //canvas.gameObject.SetActive(false);
    }

    public void ShowWidget()
    {
        canvas.gameObject.SetActive(true);
    }

    public void OnInteract()
    {
        gameObject.SetActive(false);
    }

    public bool CanInteract()
    {
        return true;
    }
}

