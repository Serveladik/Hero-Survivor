using UnityEngine;

[CreateAssetMenu(fileName = "NewWoodResource", menuName = "Resources/WoodResource")]
public class WoodResource : ScriptableObject
{
    public Sprite image;
    public ResourceTypeWood resourceType;
    public int amount;
}

