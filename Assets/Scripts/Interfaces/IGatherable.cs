public interface IGatherable
{
    void Gather(PlayerGathering player);
    ResourceTypeWood GetWoodResourceType();
    ResourceTypeRock GetRockResourceType();
    ResourceTypeSword GetSwordResourceType();
}