using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public Texture texture { get; private set; }

    private void Start()
    {
        texture = GetComponent<RawImage>().texture;
    }
}
