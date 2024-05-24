using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Dictionary<ResourceTypeWood, int> resourcesWood = new Dictionary<ResourceTypeWood, int>();
    private Dictionary<ResourceTypeRock, int> resourcesRock = new Dictionary<ResourceTypeRock, int>();
    private Dictionary<ResourceTypeSword, int> resourcesSword = new Dictionary<ResourceTypeSword, int>();

    public void CollectWood(ResourceTypeWood type, int amount)
    {
        if (resourcesWood.ContainsKey(type))
        {
            resourcesWood[type] += amount;
        }
        else
        {
            resourcesWood[type] = amount;
        }
        Debug.Log($"Collected {amount} of {type}. Total: {resourcesWood[type]}");
    }

    public void CollectRock(ResourceTypeRock type, int amount)
    {
        if (resourcesRock.ContainsKey(type))
        {
            resourcesRock[type] += amount;
        }
        else
        {
            resourcesRock[type] = amount;
        }
        Debug.Log($"Collected {amount} of {type}. Total: {resourcesRock[type]}");
    }

    public void CollectSword(ResourceTypeSword type, int amount)
    {
        if (resourcesSword.ContainsKey(type))
        {
            resourcesSword[type] += amount;
        }
        else
        {
            resourcesSword[type] = amount;
        }
        Debug.Log($"Collected {amount} of {type}. Total: {resourcesSword[type]}");
    }

    public int GetAmount(ResourceTypeWood type)
    {
        return resourcesWood.ContainsKey(type) ? resourcesWood[type] : 0;
    }

    public int GetAmount(ResourceTypeRock type)
    {
        return resourcesRock.ContainsKey(type) ? resourcesRock[type] : 0;
    }

    public int GetAmount(ResourceTypeSword type)
    {
        return resourcesSword.ContainsKey(type) ? resourcesSword[type] : 0;
    }

    public bool DeductResources(ResourceTypeWood type, int amount)
    {
        if (resourcesWood.ContainsKey(type) && resourcesWood[type] >= amount)
        {
            resourcesWood[type] -= amount;
            return true;
        }
        return false;
    }

    public bool DeductResources(ResourceTypeRock type, int amount)
    {
        if (resourcesRock.ContainsKey(type) && resourcesRock[type] >= amount)
        {
            resourcesRock[type] -= amount;
            return true;
        }
        return false;
    }

    public bool DeductResources(ResourceTypeSword type, int amount)
    {
        if (resourcesSword.ContainsKey(type) && resourcesSword[type] >= amount)
        {
            resourcesSword[type] -= amount;
            return true;
        }
        return false;
    }
}
