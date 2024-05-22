using UnityEngine;

public class Player : MonoBehaviour
{
    public Resource resource;
    public Tool tool;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3.0f);
        foreach (var collider in colliders)
        {
            IGatherable gatherable = collider.GetComponent<IGatherable>();
            if (gatherable != null && tool.CanMine(gatherable.GetResourceType()))
            {
                gatherable.Gather(this);
                Debug.LogError("Gathering " + gatherable.GetType().Name);
            }
        }
    }


    // Collect resources via the Resource component
    public void CollectResource(ResourceType type, int amount)
    {
        resource.Collect(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    // Mine resources
    public void MineResource(ResourceType type, int baseAmount)
    {
        if (tool.CanMine(type))
        {
            CollectResource(type, baseAmount);
        }
        else
        {
            Debug.Log($"Cannot mine {type} yet. Upgrade required.");
        }
    }
}
