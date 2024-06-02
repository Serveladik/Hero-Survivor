using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public List<WoodResource> woodResources;
    public List<RockResource> rockResources;
    public List<SwordResource> swordResources;

    
    public void CollectWood(ResourceTypeWood type, int amount)
    {
        WoodResource resource = woodResources.Find(r => r.resourceType == type);
        if (resource != null)
        {
            resource.amount += amount;
            Debug.Log($"Collected {amount} of {type}. Total: {resource.amount}");
        }
    }

    public void CollectRock(ResourceTypeRock type, int amount)
    {
        RockResource resource = rockResources.Find(r => r.resourceType == type);
        if (resource != null)
        {
            resource.amount += amount;
            Debug.Log($"Collected {amount} of {type}. Total: {resource.amount}");
        }
    }

    public void CollectSword(ResourceTypeSword type, int amount)
    {
        SwordResource resource = swordResources.Find(r => r.resourceType == type);
        if (resource != null)
        {
            resource.amount += amount;
            Debug.Log($"Collected {amount} of {type}. Total: {resource.amount}");
        }
    }

    public bool DeductResources(ResourceTypeWood type, int amount)
    {
        WoodResource resource = woodResources.Find(r => r.resourceType == type);
        if (resource != null && resource.amount >= amount)
        {
            resource.amount -= amount;
            ResourceManagerUI.ResourceGathered?.Invoke();
            return true;
        }
        return false;
    }

    public bool DeductResources(ResourceTypeRock type, int amount)
    {
        RockResource resource = rockResources.Find(r => r.resourceType == type);
        if (resource != null && resource.amount >= amount)
        {
            resource.amount -= amount;
            ResourceManagerUI.ResourceGathered?.Invoke();
            return true;
        }
        return false;
    }

    public bool DeductResources(ResourceTypeSword type, int amount)
    {
        SwordResource resource = swordResources.Find(r => r.resourceType == type);
        if (resource != null && resource.amount >= amount)
        {
            resource.amount -= amount;
            ResourceManagerUI.ResourceGathered?.Invoke();
            return true;
        }
        return false;
    }

    public Sprite GetResourceImage(ResourceTypeWood type)
    {
        WoodResource resource = woodResources.Find(r => r.resourceType == type);
        return resource?.image;
    }

    public Sprite GetResourceImage(ResourceTypeRock type)
    {
        RockResource resource = rockResources.Find(r => r.resourceType == type);
        return resource?.image;
    }

    public Sprite GetResourceImage(ResourceTypeSword type)
    {
        SwordResource resource = swordResources.Find(r => r.resourceType == type);
        return resource?.image;
    }

    public bool HasEnoughResources(ResourceTypeWood type, int amount)
    {
        WoodResource resource = woodResources.Find(r => r.resourceType == type);
        return resource != null && resource.amount >= amount;
    }

    public bool HasEnoughResources(ResourceTypeRock type, int amount)
    {
        RockResource resource = rockResources.Find(r => r.resourceType == type);
        return resource != null && resource.amount >= amount;
    }

    public bool HasEnoughResources(ResourceTypeSword type, int amount)
    {
        SwordResource resource = swordResources.Find(r => r.resourceType == type);
        return resource != null && resource.amount >= amount;
    }

}
