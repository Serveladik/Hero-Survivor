using UnityEngine;

[CreateAssetMenu(fileName = "NewSwordResource", menuName = "Resources/SwordResource")]
public class SwordResource : ScriptableObject
{
    public Sprite image;
    public ResourceTypeSword resourceType;
    public int amount;
}
