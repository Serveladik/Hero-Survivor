using UnityEngine;
using CnControls;
public class PlayerLookAtDirection : MonoBehaviour
{
    public Transform playerModel; // Reference to the player model's transform

    void Update()
    {
        float horizontalInput = GameManager.Instance.joystick.HorizontalAxis.Value;
        float verticalInput = GameManager.Instance.joystick.VerticalAxis.Value;

        // Calculate the movement direction based on the input values
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If the movement direction has a magnitude (i.e., the player is moving)
        if (movementDirection.magnitude > 0)
        {
            // Rotate the player model to face the movement direction
            playerModel.rotation = Quaternion.LookRotation(movementDirection.normalized, Vector3.up);
        }
    }
}
