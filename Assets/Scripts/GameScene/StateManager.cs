using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
