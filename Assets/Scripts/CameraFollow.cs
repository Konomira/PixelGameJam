using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public float smoothTime = 0.3f; // The time taken to reach the target
    public Vector3 offset; // The offset of the camera from the target

    private Vector3 velocity = Vector3.zero;
    private void Awake()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            transform.position = smoothedPosition;
        }
    }
}
