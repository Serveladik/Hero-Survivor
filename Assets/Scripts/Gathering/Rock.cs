using UnityEngine;

public class Rock : Gatherable
{
    public ResourceTypeRock rockType;

    public override ResourceTypeWood GetWoodResourceType()
    {
        return ResourceTypeWood.Default; // Rocks don't yield wood
    }

    public override ResourceTypeRock GetRockResourceType()
    {
        return rockType;
    }

    public override ResourceTypeSword GetSwordResourceType()
    {
        return ResourceTypeSword.Default; // Rocks don't yield swords
    }
}
