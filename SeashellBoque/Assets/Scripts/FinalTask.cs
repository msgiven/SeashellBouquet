using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalTask : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas interactionCanvas;
    [SerializeField] private Canvas taskCanvas;
    [SerializeField] private GameEventSO onSideTaskSolved;
    private const int maxTaskAmount = 5;
    private int solvedTaskAmount;

    private void Start()
    {
        solvedTaskAmount = 0;
        onSideTaskSolved.OnRaise.AddListener(OnSideTaskSolved);
        interactionCanvas.gameObject.SetActive(false);
        taskCanvas.gameObject.SetActive(false);
    }
    public void OnSideTaskSolved()  
    {
        solvedTaskAmount++;
        Debug.Log(solvedTaskAmount);
        if(solvedTaskAmount == maxTaskAmount)
        {
            ShowWidget();
        }

    }
    public void ShowWidget()
    {
        interactionCanvas.gameObject.SetActive(true);
    }

    public void OnInteract()
    {
        taskCanvas.gameObject.SetActive(true);
        interactionCanvas.gameObject.SetActive(false);
    }

    public bool CanInteract()
    {
        return interactionCanvas.gameObject.activeSelf;
    }
}