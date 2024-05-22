using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    // Method to collect a specific resource
    public void Collect(ResourceType type, int amount)
    {
        if (resources.ContainsKey(type))
        {
            resources[type] += amount;
        }
        else
        {
            resources[type] = amount;
        }
        Debug.Log($"Collected {amount} of {type}. Total: {resources[type]}");
    }

    // Get the amount of a specific resource
    public int GetAmount(ResourceType type)
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }

    // Deduct resources
    public bool Deduct(ResourceType type, int amount)
    {
        if (resources.ContainsKey(type) && resources[type] >= amount)
        {
            resources[type] -= amount;
            return true;
        }
        return false;
    }
}
