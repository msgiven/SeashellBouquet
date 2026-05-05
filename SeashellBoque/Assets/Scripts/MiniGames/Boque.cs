using UnityEngine;
using UnityEngine.UI;

public class Boque : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] RawImage[] seashells;
    [SerializeField] GameEventSO onPutSeashell;
    [SerializeField] GameEventSO completeFinalTask;

    private int seashellAmount;
    private void Start()
    {
        if (canvas==null) canvas = GetComponent<Canvas>();
        onPutSeashell.OnRaise.AddListener(OnPutSeashell);
    }

    private void OnPutSeashell()
    {
        seashellAmount++;
        if (seashellAmount == seashells.Length)
        {
            completeFinalTask.Raise();
            canvas.gameObject.SetActive(false);
        }
    }

}
