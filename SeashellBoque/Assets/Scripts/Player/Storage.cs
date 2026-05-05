using UnityEngine;

public class Storage : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas interactCanvas;
    [SerializeField] private Canvas taskCanvas;
    [SerializeField] private FinalTask finalTask;
    [SerializeField] private GameEventSO OnTaskSolved;
    public bool canInteract { get; private set; }



    private void Start()
    {
        canInteract = true;
        taskCanvas.gameObject.SetActive(false);
    }

    public void OnInteract()
    {
        taskCanvas.gameObject.SetActive(true);
        //interactCanvas.gameObject.SetActive(true);
    }

    public bool CanInteract()
    {
        return canInteract;
    }

    public void GiveItem()
    {
        OnTaskSolved.Raise();
        taskCanvas.gameObject.SetActive(false);
        interactCanvas.gameObject.SetActive(false);
    }

}

