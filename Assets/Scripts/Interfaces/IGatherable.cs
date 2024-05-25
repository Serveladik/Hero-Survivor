public interface IGatherable
{
    bool IsSpawning();
    void Gather(PlayerGathering player);
    ResourceTypeWood GetWoodResourceType();
    ResourceTypeRock GetRockResourceType();
    ResourceTypeSword GetSwordResourceType();
}