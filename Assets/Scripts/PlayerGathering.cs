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
            if (gatherable != null && !gatherable.IsSpawning())
            {
                gatherable.Gather(this);
            }
        }
    }

    public void CollectResource(ResourceTypeWood type, int amount)
    {
        //ResourceManagerUI.ResourceGathered?.Invoke();
        resource.CollectWood(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    public void CollectResource(ResourceTypeRock type, int amount)
    {
        //ResourceManagerUI.ResourceGathered?.Invoke();
        resource.CollectRock(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

    public void CollectResource(ResourceTypeSword type, int amount)
    {
        //ResourceManagerUI.ResourceGathered?.Invoke();
        resource.CollectSword(type, (int)(amount * tool.GetMiningSpeedMultiplier()));
    }

}
