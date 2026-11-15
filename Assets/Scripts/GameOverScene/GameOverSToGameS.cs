using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSToGameS : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
