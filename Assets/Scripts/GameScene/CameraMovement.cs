using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float TargetOrthoGraphicSize;
    [SerializeField] float MovementSpeed;
    Camera CC;

    private void Start()
    {
        CC = GetComponent<Camera>();
        targetPosition = transform.position;
        TargetOrthoGraphicSize = CC.orthographicSize;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition,MovementSpeed * Time.deltaTime);
        CC.orthographicSize = Mathf.Lerp(CC.orthographicSize, TargetOrthoGraphicSize, MovementSpeed * Time.deltaTime);
    }
}
