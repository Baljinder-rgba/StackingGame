using UnityEngine;

public class MaxHeightCalculator : MonoBehaviour
{
    float TopPointOfPlatform = -4.675f; // Change it when change platform position

    public float MaxHeightCalculate(Vector3 BlockPositionAfterCollision)
    {
        float TopPointOfThisBlock = BlockPositionAfterCollision.y + (0.7f / 2);
        float maxheightOfThisblock = TopPointOfThisBlock - TopPointOfPlatform;
        return maxheightOfThisblock;
    }
}
