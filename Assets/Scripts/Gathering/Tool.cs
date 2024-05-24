using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private Dictionary<ResourceTypeWood, bool> woodResourceAccess = new Dictionary<ResourceTypeWood, bool>();
    private Dictionary<ResourceTypeRock, bool> rockResourceAccess = new Dictionary<ResourceTypeRock, bool>();
    private Dictionary<ResourceTypeSword, bool> swordResourceAccess = new Dictionary<ResourceTypeSword, bool>();
    private float miningSpeedMultiplier = 1.0f;
    private int axeLevel = 0;
    private int pickaxeLevel = 0;
    private int swordLevel = 0;
    public bool axeUpgradedThisLevel = false;
    public bool pickaxeUpgradedThisLevel = false;
    public bool swordUpgradedThisLevel = false;

    private void Start()
    {
        // Initialize the default resources that can be accessed
        woodResourceAccess[ResourceTypeWood.OakWood] = true; // Default wood type
        rockResourceAccess[ResourceTypeRock.IronOre] = true; // Default rock type
    }

    public void UpgradeAxe(ResourceTypeWood newResource)
    {
        woodResourceAccess[newResource] = true;
        axeLevel++;
        axeUpgradedThisLevel = true;
        UpdateMiningSpeed();
        Debug.Log($"Axe upgraded. Now can gather {newResource} and current level resources faster.");
    }

    // Upgrade pickaxe to access new resources and increase mining speed
    public void UpgradePickaxe(ResourceTypeRock newResource)
    {
        rockResourceAccess[newResource] = true;
        pickaxeLevel++;
        pickaxeUpgradedThisLevel = true;
        UpdateMiningSpeed();
        Debug.Log($"Pickaxe upgraded. Now can gather {newResource} and current level resources faster.");
    }

    public void UpgradeSword(ResourceTypeSword newResource)
    {
        swordResourceAccess[newResource] = true;
        swordLevel++;
        swordUpgradedThisLevel = true;
        UpdateMiningSpeed();
        Debug.Log($"Pickaxe upgraded. Now can gather {newResource} and current level resources faster.");
    }

    // Update mining speed based on tool levels
    private void UpdateMiningSpeed()
    {
        miningSpeedMultiplier = 1.0f + 0.5f * Mathf.Min(axeLevel, pickaxeLevel);  // Example: 1.5x speed per level
    }

    // Check if a wood resource can be gathered
    public bool CanGatherWood(ResourceTypeWood type)
    {
        return woodResourceAccess.ContainsKey(type) && woodResourceAccess[type];
    }

    // Check if a rock resource can be gathered
    public bool CanGatherRock(ResourceTypeRock type)
    {
        return rockResourceAccess.ContainsKey(type) && rockResourceAccess[type];
    }

    public bool CanGatherSword(ResourceTypeSword type)
    {
        return swordResourceAccess.ContainsKey(type) && swordResourceAccess[type];
    }

    // Reset upgrade flags for the new level
    public void ResetUpgradesForNewLevel()
    {
        axeUpgradedThisLevel = false;
        pickaxeUpgradedThisLevel = false;
    }

    public float GetMiningSpeedMultiplier()
    {
        return miningSpeedMultiplier;
    }
}
