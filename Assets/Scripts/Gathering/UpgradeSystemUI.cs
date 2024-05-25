using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UpgradeSystemUI : MonoBehaviour
{
    public GameObject upgradeUI;
    public float detectionRadius = 5f;
    private PlayerGathering playerGathering;
    private Camera mainCamera;

    void Start()
    {
        playerGathering = GameManager.Instance.playerGathering;
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
            if (!playerGathering.tool.axeUpgradedThisLevel && !playerGathering.tool.pickaxeUpgradedThisLevel)
            {
                upgradeUI.SetActive(true);
            }
            else
            {
                upgradeUI.SetActive(false);
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
            // Rotate the UI to face the camera
            Vector3 direction = transform.position - mainCamera.transform.position;
            upgradeUI.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
