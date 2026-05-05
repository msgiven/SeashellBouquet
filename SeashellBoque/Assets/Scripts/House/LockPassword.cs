using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LockPassword : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordIF;
    private string correctPassword = "170425";

    public void OnEndInput()
    {
        if (passwordIF.text == correctPassword)
        {
            SceneManager.LoadScene("HouseScene");
        }
    }
}
