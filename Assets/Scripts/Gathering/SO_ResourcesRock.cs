using UnityEngine;

[CreateAssetMenu(fileName = "NewRockResource", menuName = "Resources/RockResource")]
public class RockResource : ScriptableObject
{
    public Sprite image;
    public ResourceTypeRock resourceType;
    public int amount;
}
