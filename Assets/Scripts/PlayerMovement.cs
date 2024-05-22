using UnityEngine;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float climbThreshold = 2f; // Adjust the climb threshold as needed
    public float climbSmoothness = 5f; // Adjust climb smoothness as needed

    private Rigidbody rb;
    private Vector3 targetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get the input values from the joystick
        float horizontalInput = GameManager.Instance.joystick.HorizontalAxis.Value;
        float verticalInput = GameManager.Instance.joystick.VerticalAxis.Value;

        // Calculate the movement direction based on the input values
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, 0.5f))
        {
            Bounds colliderBounds = hit.collider.bounds;

            float maxClimbHeight = transform.localScale.y * climbThreshold;

            // Check if the hit object's height is less than twice the player's height
            if (colliderBounds.size.y <= maxClimbHeight)
            {
                targetPosition = hit.point + Vector3.up * (colliderBounds.size.y / 2f); 
                rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * climbSmoothness));
                return;
            }
        }

        // Apply the normal movement to the player's rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
