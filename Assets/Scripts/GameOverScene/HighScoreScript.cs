using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    TextMeshProUGUI Score;
    private void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
        Score.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
