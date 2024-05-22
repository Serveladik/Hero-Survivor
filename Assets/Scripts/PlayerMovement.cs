using UnityEngine;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float climbThreshold = 2f; // Adjust the climb threshold as needed
    public SimpleJoystick joystick;
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
        float horizontalInput = joystick.HorizontalAxis.Value;
        float verticalInput = joystick.VerticalAxis.Value;

        // Calculate the movement direction based on the input values
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if there's an object to climb
        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, 0.5f))
        {
            // Get the collider's bounds
            Bounds colliderBounds = hit.collider.bounds;

            // Calculate the maximum climb height (twice the player's height)
            float maxClimbHeight = transform.localScale.y * climbThreshold;

            // Check if the hit object's height is less than twice the player's height
            if (colliderBounds.size.y <= maxClimbHeight)
            {
                // Calculate the target position for climbing
                targetPosition = hit.point + Vector3.up * (colliderBounds.size.y / 2f); // Adjust the offset as needed

                // Move the player smoothly towards the climbing position
                rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * climbSmoothness));
                return; // Skip normal movement if climbing
            }
        }

        // Apply the normal movement to the player's rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
