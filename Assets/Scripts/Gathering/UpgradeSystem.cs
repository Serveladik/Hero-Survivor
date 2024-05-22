using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public Player player;
    public ResourceType requiredResourceForAxeUpgrade;
    public int resourceAmountForAxeUpgrade = 10;

    public ResourceType requiredResourceForPickaxeUpgrade;
    public int resourceAmountForPickaxeUpgrade = 10;
    public ResourceType newResourceForAxe = ResourceType.PineWood;
    public ResourceType newResourceForPickaxe = ResourceType.CopperOre;

    public void UpgradeAxe()
    {
        if (!player.tool.axeUpgradedThisLevel && player.resource.Deduct(requiredResourceForAxeUpgrade, resourceAmountForAxeUpgrade))
        {
            player.tool.UpgradeAxe(newResourceForAxe);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade axe or axe already upgraded on this level");
        }
    }

    public void UpgradePickaxe()
    {
        if (!player.tool.pickaxeUpgradedThisLevel && player.resource.Deduct(requiredResourceForPickaxeUpgrade, resourceAmountForPickaxeUpgrade))
        {
            player.tool.UpgradePickaxe(newResourceForPickaxe);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade pickaxe or pickaxe already upgraded on this level");
        }
    }
}
