using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    SpriteRenderer IR;
    private void Start()
    {
        IR = GetComponent<SpriteRenderer>();
        IR.color = Random.ColorHSV();
    }
}
