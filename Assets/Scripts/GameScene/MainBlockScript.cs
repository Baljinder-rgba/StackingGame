using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class MainBlockScript : MonoBehaviour
{
    // This GameObject Components
    Rigidbody2D rb;

    // GameObjects
    GameObject MainCameraObject;
    [SerializeField] GameObject Shape1;
    [SerializeField] GameObject Shape2;
    [SerializeField] GameObject Shape3;
    [SerializeField] GameObject Shape4;

    // Fellow Script Objects
    Camera CameraComponent;
    CameraMovement CMScript;
    MaxHeightCalculator MHCObject;

    // Quantities
    Vector3 SpawnLocation;
    float MovementRange = 2;
    int MovementDirection = 1;
    float MovementSpeed = 2;
    bool hasLanded = false;
    float spawnY;

    [SerializeField] float ThisBlockHeight = 0.7f; // Actual height of this block

    // UI
    GameObject ScoreObject;
    TextMeshProUGUI Score;

    private void Start()
    {
        // Rigidbody
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        rb.freezeRotation = true;

        // Camera Stuff
        MainCameraObject = GameObject.Find("Main Camera");
        CameraComponent = MainCameraObject.GetComponent<Camera>();
        MHCObject = new MaxHeightCalculator();
        CMScript = MainCameraObject.GetComponent<CameraMovement>();

        // Score UI
        ScoreObject = GameObject.Find("Score");
        Score = ScoreObject.GetComponent<TextMeshProUGUI>();

        spawnY = PlayerPrefs.GetFloat("SpawningHeight");
        SpawnLocation = new Vector3(0, spawnY, 0);
    }

    private void Update()
    {
        // Direction Shifting
        if (transform.position.x >= MovementRange)
        {
            MovementDirection = -1;
        }
        else if (transform.position.x <= -MovementRange)
        {
            MovementDirection = 1;
        }

        // Sideward Motion Before Falling
        transform.Translate(MovementDirection * MovementSpeed * Time.deltaTime, 0, 0);

        // Dropping (Space key OR Touch)
        if (Input.GetKeyDown(KeyCode.Space) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            MovementDirection = 0;
            MovementSpeed = 0;
            rb.simulated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hasLanded == false) &&
            (collision.gameObject.CompareTag("Base") || collision.gameObject.CompareTag("Block")))
        {
            hasLanded = true;

            // Score Increment
            int score = Convert.ToInt32(Score.text);
            score++;
            Score.text = score.ToString();
            PlayerPrefs.SetInt("Score", Convert.ToInt32(Score.text));

            if (collision.gameObject.CompareTag("Block"))
            {
                checkStability(transform.position.x, collision.gameObject.transform.position.x);
            }

            // Maximum Height of tower Calculate
            float HeightOfTHisBLock = MHCObject.MaxHeightCalculate(transform.position);
            if (HeightOfTHisBLock > PlayerPrefs.GetFloat("MaxHeight"))
            {
                PlayerPrefs.SetFloat("MaxHeight", HeightOfTHisBLock);

                // Camera Movement and Orthographic size Sync
                Vector3 newCameraPosition =
                    MainCameraObject.transform.position + new Vector3(0, ThisBlockHeight / 2, 0);
                CMScript.targetPosition = newCameraPosition;

                CMScript.TargetOrthoGraphicSize =
                    CameraComponent.orthographicSize + ThisBlockHeight / 2;

                spawnY = spawnY + ThisBlockHeight;
                PlayerPrefs.SetFloat("SpawningHeight", spawnY);
            }

            // Increasing Movement Range
            MovementRange = MovementRange + 0.8f;

            // Generate New Block (Shape)
            int RandomNumber = UnityEngine.Random.Range(0, 4);

            if (RandomNumber == 0)
            {
                Instantiate(Shape1, SpawnLocation, Quaternion.identity);
            }
            else if (RandomNumber == 1)
            {
                Instantiate(Shape2, SpawnLocation, Quaternion.identity);
            }
            else if (RandomNumber == 2)
            {
                Instantiate(Shape3, SpawnLocation, Quaternion.identity);
            }
            else if (RandomNumber == 3)
            {
                Instantiate(Shape4, SpawnLocation, Quaternion.identity);
            }
            else
            {
                Debug.Log("No shape Generated, RandomNumber Out of bound");
            }
        }
    }

    void checkStability(float currentBlockX, float BottomBlockX)
    {
        float distance = Mathf.Abs(currentBlockX - BottomBlockX);
        if (distance > 0.5f)
        {
            rb.freezeRotation = false;
        }
    }

    IEnumerator delayedRotation()
    {
        yield return new WaitForSeconds(2);
        rb.freezeRotation = false;
    }
}
