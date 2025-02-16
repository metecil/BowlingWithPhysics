using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator; // Used later for aiming

    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        // Parent the ball to the BallAnchor and reset its local position
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

        // Make the ball kinematic until it is fired
        ballRB.isKinematic = true;
        ResetBall();
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;

        // Unparent the ball so it is no longer affected by the player
        transform.parent = null;

        // Enable physics by setting isKinematic to false
        ballRB.isKinematic = false;

        // Apply force to the ball; here you could also use the launchIndicator for direction
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
