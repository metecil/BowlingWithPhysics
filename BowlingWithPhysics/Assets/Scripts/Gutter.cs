using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        Debug.Log("Gutter triggered by: " + triggeredBody.gameObject.name);

        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
        if (ballRigidBody == null)
        {
            Debug.LogWarning("No Rigidbody found on " + triggeredBody.gameObject.name);
            return;
        }

        // Get the magnitude of the current velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // Reset the ball's movement
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        Vector3 forceVector = Vector3.forward * velocityMagnitude;

        // Apply force to the ball
        ballRigidBody.AddForce(forceVector, ForceMode.VelocityChange);

        Debug.Log("New velocity after applying force: " + ballRigidBody.linearVelocity);
    }
}
