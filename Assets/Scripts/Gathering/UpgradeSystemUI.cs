using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(UpgradeSystem))]
public class UpgradeSystemUI : MonoBehaviour
{
    private UpgradeSystem upgradeSystem;
    public GameObject upgradeUI;
    public float detectionRadius = 5f;
    private PlayerGathering playerGathering;
    private Camera mainCamera;

    void Start()
    {
        playerGathering = GameManager.Instance.playerGathering;
        upgradeSystem = GetComponent<UpgradeSystem>();
        upgradeUI.SetActive(false); // Ensure the UI is initially hidden
        mainCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        CheckDistance(GameManager.Instance.player.transform);
        UiToCamera(); // Make the UI face the camera
    }

    private void CheckDistance(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <= detectionRadius)
        {
            switch (upgradeSystem.upgradeType)
            {
                case UpgradeSystem.UpgradeType.Axe:
                    upgradeUI.SetActive(!playerGathering.tool.axeUpgradedThisLevel);
                    break;
                case UpgradeSystem.UpgradeType.Pickaxe:
                    upgradeUI.SetActive(!playerGathering.tool.pickaxeUpgradedThisLevel);
                    break;
                case UpgradeSystem.UpgradeType.Sword:
                    upgradeUI.SetActive(!playerGathering.tool.swordUpgradedThisLevel);
                    break;
            }
        }
        else
        {
            upgradeUI.SetActive(false);
        }
    }

    private void UiToCamera()
    {
        if (upgradeUI.activeSelf)
        {
            Vector3 direction = transform.position - mainCamera.transform.position;
            upgradeUI.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
