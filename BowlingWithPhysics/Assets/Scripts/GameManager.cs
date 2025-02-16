using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    // Ball reference
    [SerializeField] private BallController ball;

    // Prefab for the pin collection (contains multiple pins)
    [SerializeField] private GameObject pinCollection;

    // Transform where new pins will spawn
    [SerializeField] private Transform pinAnchor;

    // Reference to our input manager
    [SerializeField] private InputManager inputManager;

    // TextMeshPro component that displays the score
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        // Listen for the R key
        inputManager.OnResetPressed.AddListener(HandleReset);
        // Set up pins when the game starts
        SetPins();
    }

    private void HandleReset()
    {
        // Reset the ball first
        ball.ResetBall();
        // Then reset the pins
        SetPins();
    }

    private void SetPins()
    {
        // Destroy old pin instances if they exist
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // Instantiate the pinCollection prefab at pinAnchor
        pinObjects = Instantiate(
            pinCollection,
            pinAnchor.transform.position,
            Quaternion.identity,
            transform
        );

        // Subscribe the IncrementScore() method to each new pin's OnPinFall event
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
