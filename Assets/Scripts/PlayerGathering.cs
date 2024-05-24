using UnityEngine;

public class PlayerGathering : MonoBehaviour
{
    public Resource resource;
    public Tool tool;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3.0f);
        foreach (var collider in colliders)
        {
            IGatherable gatherable = collider.GetComponent<IGatherable>();
            if (gatherable != null)
            {
                gatherable.Gather(this);
            }
        }
    }

    // Collect wood resources
    public void CollectResource(ResourceTypeWood type, int amount)
    {
        resource.CollectWood(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    // Collect rock resources
    public void CollectResource(ResourceTypeRock type, int amount)
    {
        resource.CollectRock(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    public void CollectResource(ResourceTypeSword type, int amount)
    {
        resource.CollectSword(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    // Mine wood resources
    public void MineResource(ResourceTypeWood type, int baseAmount)
    {
        if (tool.CanGatherWood(type))
        {
            CollectResource(type, baseAmount);
        }
        else
        {
            Debug.Log($"Cannot gather {type}. Upgrade required.");
        }
    }

    // Mine rock resources
    public void MineResource(ResourceTypeRock type, int baseAmount)
    {
        if (tool.CanGatherRock(type))
        {
            CollectResource(type, baseAmount);
        }
        else
        {
            Debug.Log($"Cannot gather {type}. Upgrade required.");
        }
    }
}
