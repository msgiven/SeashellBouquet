using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IrisWipeController : MonoBehaviour
{
    [SerializeField] private Image wipeImage;
    [SerializeField] private float transitionDuration = 4.0f;

    private Material wipeMaterial;
    private readonly int radiusPropertyId = Shader.PropertyToID("_Scale");

    private void Awake()
    {
        if (wipeImage != null)
        {
            wipeMaterial = new Material(wipeImage.material);
            wipeImage.material = wipeMaterial;
        }
    }
    public void CloseIris()
    {
        Debug.Log("AASASAS");
        StartCoroutine(AnimateRadius(1.6f, 0.001f));
    }

    public void OpenIris()
    {
        StartCoroutine(AnimateRadius(0f, 1.5f));
    }

    private IEnumerator AnimateRadius(float startRadius, float endRadius)
    {
        float timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            timeElapsed += Time.deltaTime;
            float currentRadius = Mathf.Lerp(startRadius, endRadius, timeElapsed / transitionDuration);
            wipeMaterial.SetFloat(radiusPropertyId, currentRadius);
            yield return null;
        }

        wipeMaterial.SetFloat(radiusPropertyId, endRadius);
    }
}