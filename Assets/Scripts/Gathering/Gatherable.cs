using System.Collections;
using UnityEngine;

public abstract class Gatherable : MonoBehaviour, IGatherable
{
    public int resourceAmount = 5;
    public float respawnTime = 10f;
    public float wobbleDuration = 0.2f;
    public float wobbleAmount = 0.1f;

    protected bool isSpawning = false;
    protected bool isBeingMined = false;
    protected Vector3[] originalScales;

    protected virtual void Start()
    {
        originalScales = new Vector3[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            originalScales[i] = child.localScale;
            i++;
        }
    }

    public abstract ResourceTypeWood GetWoodResourceType();
    public abstract ResourceTypeRock GetRockResourceType();
    public abstract ResourceTypeSword GetSwordResourceType();
    
    public bool IsSpawning()
    {
        return isSpawning;
    }
    public void Gather(PlayerGathering player)
    {
        ResourceTypeWood woodType = GetWoodResourceType();
        ResourceTypeRock rockType = GetRockResourceType();
        ResourceTypeSword swordType = GetSwordResourceType();

        if (!isBeingMined && 
            (player.tool.CanGatherWood(woodType) || 
            player.tool.CanGatherRock(rockType) || 
            player.tool.CanGatherSword(swordType)))
        {
            StartCoroutine(ChopCoroutine(player, woodType, rockType, swordType));
            ResourceManagerUI.ResourceGathered?.Invoke();
        }
        else
        {
            Debug.Log($"Cannot gather {gameObject.name}. Upgrade required or already collected.");
        }
    }

    private IEnumerator ChopCoroutine(PlayerGathering player, ResourceTypeWood woodType, ResourceTypeRock rockType, ResourceTypeSword swordType)
    {
        isBeingMined = true;
        StartCoroutine(WobbleChildren());
        if (woodType != ResourceTypeWood.Default)
            player.CollectResource(woodType, resourceAmount);
        if (rockType != ResourceTypeRock.Default)
            player.CollectResource(rockType, resourceAmount);
        if (swordType != ResourceTypeSword.Default)
            player.CollectResource(swordType, resourceAmount);
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
        isSpawning = true;
        yield return new WaitForSeconds(respawnTime);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        isSpawning = false;
    }
}
