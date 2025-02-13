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

        Debug.Log("Is Rigidbody kinematic? " + ballRigidBody.isKinematic);
        Debug.Log("Current velocity: " + ballRigidBody.linearVelocity);

        // Get the magnitude of the current velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
        Debug.Log("Velocity magnitude: " + velocityMagnitude);

        // Reset the ball's movement
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        Debug.Log("Velocity reset to: " + ballRigidBody.linearVelocity);

        // Instead of using transform.forward, use Vector3.forward to always push along the z axis.
        Vector3 forceVector = Vector3.forward * velocityMagnitude;
        Debug.Log("Force vector to apply: " + forceVector);

        // Apply force to the ball
        ballRigidBody.AddForce(forceVector, ForceMode.VelocityChange);

        Debug.Log("New velocity after applying force: " + ballRigidBody.linearVelocity);
    }
}
