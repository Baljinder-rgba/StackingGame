using UnityEngine;

public class InitialSetup : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetFloat("MaxHeight", 0);
        PlayerPrefs.SetFloat("SpawningHeight", 3);
        PlayerPrefs.SetInt("Score", 0);
    }
}
