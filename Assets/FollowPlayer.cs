using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;                        // Assign the Player here in Inspector
    public Vector3 offset = new Vector3(0, 0, -10); // Keeps camera behind the scene
    public float smoothSpeed = 0.125f;              // Smoothing factor (tweak to preference)

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is NULL!");
            return;
        }

        // Optional: Log camera tracking for debugging
        Debug.Log("Camera is following: " + target.name + " | Position: " + target.position);

        // Follow with smoothing
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
