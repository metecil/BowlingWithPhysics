using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    private bool isBallLaunched;
    
    void Start()
    {
        // Grab the Rigidbody attached to the ball
        ballRB = GetComponent<Rigidbody>();

        // Subscribe to the space key event
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return; // Prevent multiple launches
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
