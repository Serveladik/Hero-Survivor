using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private Dictionary<ResourceType, bool> resourceAccess = new Dictionary<ResourceType, bool>();
    private float miningSpeedMultiplier = 1.0f;
    private int axeLevel = 0;
    private int pickaxeLevel = 0;
    public bool axeUpgradedThisLevel = false;
    public bool pickaxeUpgradedThisLevel = false;

    private void Start()
    {
        // Initialize the default resources that can be accessed
        resourceAccess[ResourceType.OakWood] = true; // Default wood type
        resourceAccess[ResourceType.IronOre] = true; // Default rock type
    }
    public void UpgradeAxe(ResourceType newResource)
    {
        resourceAccess[newResource] = true;
        axeLevel++;
        axeUpgradedThisLevel = true;
        UpdateMiningSpeed();
        Debug.Log($"Axe upgraded. Now can mine {newResource} and current level resources faster.");
    }

    // Upgrade pickaxe to access new resources and increase mining speed
    public void UpgradePickaxe(ResourceType newResource)
    {
        resourceAccess[newResource] = true;
        pickaxeLevel++;
        pickaxeUpgradedThisLevel = true;
        UpdateMiningSpeed();
        Debug.Log($"Pickaxe upgraded. Now can mine {newResource} and current level resources faster.");
    }

    // Update mining speed based on tool levels
    private void UpdateMiningSpeed()
    {
        miningSpeedMultiplier = 1.0f + 0.5f * Mathf.Min(axeLevel, pickaxeLevel);  // Example: 1.5x speed per level
    }

    // Check if a resource can be mined
    public bool CanMine(ResourceType type)
    {
        return resourceAccess.ContainsKey(type) && resourceAccess[type];
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
