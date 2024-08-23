using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    private Vector3 offset;

    void Start () {
        offset = transform.position - target.transform.position;
    }
    
    void LateUpdate () {
        // Calculate the new position based on the offset and target rotation
        Vector3 desiredPosition = target.transform.position + target.transform.rotation * offset;
        transform.position = desiredPosition;

        // Rotate the camera to always look at the target (ant)
        transform.LookAt(target.transform.position);
    }
}
