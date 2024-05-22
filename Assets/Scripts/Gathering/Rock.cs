using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour, IGatherable
{
    public ResourceType rockType;
    public int rockAmount = 5;
    public float respawnTime = 10f;
    public float wobbleDuration = 0.2f;  // Duration of one wobble cycle
    public float wobbleAmount = 0.1f;  // Scale amount for wobble

    private bool isRespawning = false;
    private bool isBeingMined = false;
    private Vector3[] originalScales; // Store original scales of child objects

    void Start()
    {
        originalScales = new Vector3[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            originalScales[i] = child.localScale;
            i++;
        }
    }

    public ResourceType GetResourceType()
    {
        return rockType;
    }

    public void Gather(Player player)
    {
        if (player.tool.CanMine(rockType) && !isRespawning && !isBeingMined)
        {
            StartCoroutine(ChopCoroutine(player));
        }
        else
        {
            Debug.Log($"Cannot chop {rockType}. Upgrade required or already collected.");
        }
    }

    private IEnumerator ChopCoroutine(Player player)
    {
        isBeingMined = true;
        StartCoroutine(WobbleChildren());
        player.MineResource(rockType, rockAmount);
        DisableNextChild();
        yield return new WaitForSeconds(1 / player.tool.GetMiningSpeedMultiplier());
        isBeingMined = false;

        if (AllChildrenDisabled())
        {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator WobbleChildren()
    {
        int wobbleCount = 1;
        for (int i = 0; i < wobbleCount; i++)
        {
            float elapsed = 0f;
            while (elapsed < wobbleDuration)
            {
                foreach (Transform child in transform)
                {
                    float scale = Mathf.Sin(elapsed * Mathf.PI * 2 / wobbleDuration) * wobbleAmount;
                    child.localScale = originalScales[child.GetSiblingIndex()] - new Vector3(scale, scale, scale);
                }
                elapsed += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); // Small pause between wobbles
        }
        foreach (Transform child in transform)
        {
            child.localScale = originalScales[child.GetSiblingIndex()]; // Reset scale to original size
        }
    }

    private void DisableNextChild()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
                break;
            }
        }
    }

    private bool AllChildrenDisabled()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator Respawn()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnTime);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        isRespawning = false;
    }
}
