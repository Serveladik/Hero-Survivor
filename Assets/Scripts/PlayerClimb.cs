using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public float maxClimbDistance = 10f;
    
    private void Update()
    {
        // Detect nearby climbable surfaces
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxClimbDistance);

        foreach (Collider collider in colliders)
        {
            // Check if the surface is higher than the player and within climbing distance
            if (Vector3.Dot(collider.transform.up, Vector3.up) > 0.0f && // Check if the surface angle is <= 90 degrees
                collider.transform.position.y > transform.position.y)
            {
                // Calculate the height difference
                float heightDifference = collider.transform.position.y - transform.position.y;

                // Ensure the height difference is within climbing range
                if (heightDifference <= maxClimbDistance)
                {
                    // Move the player upwards to the height of the surface
                    Vector3 newPosition = transform.position;
                    newPosition.y = collider.transform.position.y;
                    transform.position = newPosition;
                }
            }
        }
    }
}
