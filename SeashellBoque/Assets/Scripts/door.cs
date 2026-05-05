using GLTFast.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour, IInteractable
{
    private Canvas intCanvas;
    [SerializeField] private Canvas lockCanvas;
    private void Start()
    {
        intCanvas = GetComponentInChildren<Canvas>();
        //intCanvas.gameObject.SetActive(false);
    }

    public void ShowWidget()
    {
        intCanvas.gameObject.SetActive(true);
    }

    public void OnInteract()
    {
        lockCanvas.gameObject.SetActive(true);
    }

    public bool CanInteract()
    {
        return true;
    }
}
