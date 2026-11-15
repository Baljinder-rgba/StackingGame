using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            StateManager.GameOver();
        }
    }
}
