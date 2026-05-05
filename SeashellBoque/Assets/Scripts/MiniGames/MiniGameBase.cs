using UnityEngine;
using UnityEngine.UI;

public class MiniGameBase : MonoBehaviour
{
    [SerializeField] protected Button seashell;

    protected virtual void Start()
    {
        seashell.interactable = false;
    }

    public void TakeSeahell()
    {
        Destroy(seashell.gameObject);
    }
}
