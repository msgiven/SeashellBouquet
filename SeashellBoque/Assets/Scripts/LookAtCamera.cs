using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        Vector3 dir = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
