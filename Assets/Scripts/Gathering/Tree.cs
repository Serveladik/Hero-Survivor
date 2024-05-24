using UnityEngine;

public class Tree : Gatherable
{
    public ResourceTypeWood woodType;

    public override ResourceTypeWood GetWoodResourceType()
    {
        return woodType;
    }

    public override ResourceTypeRock GetRockResourceType()
    {
        return ResourceTypeRock.Default; // Trees don't yield rocks
    }

    public override ResourceTypeSword GetSwordResourceType()
    {
        return ResourceTypeSword.Default; // Trees don't yield swords
    }
}
