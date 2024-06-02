using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public enum UpgradeType {Axe, Pickaxe, Sword}
    public UpgradeType upgradeType;
    public PlayerGathering player;
    [Header("Resources Settings")]
    public ResourceTypeWood requiredResourceForAxeUpgrade;
    public int resourceAmountForAxeUpgrade = 10;
    public ResourceTypeRock requiredResourceForPickaxeUpgrade;
    public int resourceAmountForPickaxeUpgrade = 10;
    public ResourceTypeRock requiredResourceForSwordUpgrade;
    public int resourceAmountForSwordUpgrade = 10;
    public ResourceTypeWood newResourceForAxe = ResourceTypeWood.PineWood;
    public ResourceTypeRock newResourceForPickaxe = ResourceTypeRock.CopperOre;
    public ResourceTypeSword newResourceForSword = ResourceTypeSword.Slime;

    public TextMeshProUGUI upgradeButtonText;

    void Update()
    {
        if (upgradeButtonText.gameObject.activeInHierarchy)
        {
            UpdateStatusButton();
        }
    }

    public void OnUpgradeButtonClicked()
    {
        switch (upgradeType)
        {
            case UpgradeType.Axe:
                UpgradeAxe();
                break;
            case UpgradeType.Pickaxe:
                UpgradePickaxe();
                break;
            case UpgradeType.Sword:
                UpgradeSword();
                break;
        }
        UpdateStatusButton();
    }

    private void UpgradeAxe()
    {
        if (!player.tool.axeUpgradedThisLevel && player.resource.DeductResources(requiredResourceForAxeUpgrade, resourceAmountForAxeUpgrade))
        {
            player.tool.UpgradeAxe(newResourceForAxe);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade axe or axe already upgraded on this level");
        }
    }

    private void UpgradePickaxe()
    {
        if (!player.tool.pickaxeUpgradedThisLevel && player.resource.DeductResources(requiredResourceForPickaxeUpgrade, resourceAmountForPickaxeUpgrade))
        {
            player.tool.UpgradePickaxe(newResourceForPickaxe);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade pickaxe or pickaxe already upgraded on this level");
        }
    }

    private void UpgradeSword()
    {
        if (!player.tool.swordUpgradedThisLevel && player.resource.DeductResources(requiredResourceForSwordUpgrade, resourceAmountForSwordUpgrade))
        {
            player.tool.UpgradeSword(newResourceForSword);
        }
        else
        {
            Debug.Log("Not enough resources to upgrade sword or sword already upgraded on this level");
        }
    }

    private void UpdateStatusButton()
    {
        bool hasEnoughResources = false;

        switch (upgradeType)
        {
            case UpgradeType.Axe:
                hasEnoughResources = player.resource.HasEnoughResources(requiredResourceForAxeUpgrade, resourceAmountForAxeUpgrade);
                break;
            case UpgradeType.Pickaxe:
                hasEnoughResources = player.resource.HasEnoughResources(requiredResourceForPickaxeUpgrade, resourceAmountForPickaxeUpgrade);
                break;
            case UpgradeType.Sword:
                hasEnoughResources = player.resource.HasEnoughResources(requiredResourceForSwordUpgrade, resourceAmountForSwordUpgrade);
                break;
        }

        upgradeButtonText.color = hasEnoughResources ? Color.white : Color.red;
        upgradeButtonText.text = upgradeType.ToString() + " upgrade: " + GetRequiredResourceAmount();
    }

    private int GetRequiredResourceAmount()
    {
        switch (upgradeType)
        {
            case UpgradeType.Axe:
                return resourceAmountForAxeUpgrade;
            case UpgradeType.Pickaxe:
                return resourceAmountForPickaxeUpgrade;
            case UpgradeType.Sword:
                return resourceAmountForSwordUpgrade;
            default:
                return 0;
        }
    }

    private string GetRequiredResourceType()
    {
        switch (upgradeType)
        {
            case UpgradeType.Axe:
                return requiredResourceForAxeUpgrade.ToString();
            case UpgradeType.Pickaxe:
                return requiredResourceForPickaxeUpgrade.ToString();
            case UpgradeType.Sword:
                return requiredResourceForSwordUpgrade.ToString();
            default:
                return "";
        }
    }
}
