using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMToGameS : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
