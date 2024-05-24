using UnityEngine;

public class UpgradeSystemUI : MonoBehaviour
{
    public GameObject upgradeUI;
    public float detectionRadius = 5f;
    private PlayerGathering playerGathering;

    void Start()
    {
        playerGathering = GameManager.Instance.playerGathering;
        upgradeUI.SetActive(false); // Ensure the UI is initially hidden
    }

    void Update()
    {
        DetectPlayerProximity();
    }

    private void DetectPlayerProximity()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= detectionRadius)
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
}
