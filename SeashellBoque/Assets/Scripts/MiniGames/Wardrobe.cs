using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MiniGameBase
{
    [SerializeField] RawImage[] obstacles;
    [SerializeField] GameEventSO onPutSock;

    private int collectedSocks;
    protected override void Start()
    {
        base.Start();
        onPutSock.OnRaise.AddListener(OnPutSock);
    }

    private void OnPutSock()
    {
        collectedSocks++;
        if (collectedSocks == obstacles.Length) { 
            seashell.interactable = true;    
        }
    }

    public void TakeSeashell()
    {
        Destroy(seashell.gameObject); 
    }
}
