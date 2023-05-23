using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The target object to follow
    public Transform player; // Reference to the player object
    public float smoothSpeed = 0.125f; // The smoothness of camera movement
    public Vector3 offset; // The offset from the target object
    public float rotationSpeed = 3f; // The speed of camera rotation

    private float mouseX, mouseY; // Mouse input values

    private void Start()
    {
        // Lock and hide the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (!gameObject.activeInHierarchy) return; 
        // Get mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f); // Limit vertical rotation

        // Set camera rotation
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        transform.rotation = rotation;

        // Set player rotation
        player.rotation = Quaternion.Euler(0f, mouseX, 0f); // Rotate only around the Y-axis

        // Set camera position
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
