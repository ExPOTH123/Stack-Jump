using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick_Retry() {
        SceneManager.LoadScene("InGame");;
    }

    public void OnClick_Play() {
        SceneManager.LoadScene("InGame");;
    }

    public void OnClick_MainMenu() {
        SceneManager.LoadScene("Main Menu");;
    }
}
