using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSToMainM : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
