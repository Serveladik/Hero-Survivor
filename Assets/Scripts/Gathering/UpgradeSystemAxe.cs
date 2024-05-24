using UnityEngine;


public class UpgradeSystem : MonoBehaviour
{
    public enum UpgradeSystemType{Axe, Pickaxe, Sword};
    [Header("Upgrade type")]
    public UpgradeSystemType upgradeSystemType; 
    [Header("Resources")]
    public PlayerGathering player;
    public ResourceTypeWood requiredResourceForAxeUpgrade;
    public int resourceAmountForAxeUpgrade = 10;
    public ResourceTypeRock requiredResourceForPickaxeUpgrade;
    public int resourceAmountForPickaxeUpgrade = 10;
    public ResourceTypeSword requiredResourceForSwordUpgrade;
    public int resourceAmountForSwordUpgrade = 10;

    public void Upgrade()
    {
        switch (upgradeSystemType)
        {
            case UpgradeSystemType.Axe:
                UpgradeAxe();
                break;
            case UpgradeSystemType.Pickaxe:
                UpgradePickaxe();
                break;
            case UpgradeSystemType.Sword:
                UpgradeSword();
                break;
            default:
                Debug.LogError("Unsupported upgrade system type.");
                break;
        }
    }

    // Method to handle axe upgrade
    private void UpgradeAxe()
    {
        if (!player.tool.axeUpgradedThisLevel && player.resource.DeductResources(requiredResourceForAxeUpgrade, resourceAmountForAxeUpgrade))
        {
            player.tool.UpgradeAxe(requiredResourceForAxeUpgrade);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade axe or axe already upgraded on this level");
        }
    }

    // Method to handle pickaxe upgrade
    private void UpgradePickaxe()
    {
        if (!player.tool.pickaxeUpgradedThisLevel && player.resource.DeductResources(requiredResourceForPickaxeUpgrade, resourceAmountForPickaxeUpgrade))
        {
            player.tool.UpgradePickaxe(requiredResourceForPickaxeUpgrade);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade pickaxe or pickaxe already upgraded on this level");
        }
    }

    // Method to handle sword upgrade
    private void UpgradeSword()
    {
        if (!player.tool.swordUpgradedThisLevel && player.resource.DeductResources(requiredResourceForSwordUpgrade, resourceAmountForSwordUpgrade))
        {
            player.tool.UpgradeSword(requiredResourceForSwordUpgrade);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade sword or sword already upgraded on this level");
        }
    }
}
