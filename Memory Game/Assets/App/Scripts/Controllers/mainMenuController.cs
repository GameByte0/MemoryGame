using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 
    public void ExitGame()
    {
        Application.Quit();
    }
}
