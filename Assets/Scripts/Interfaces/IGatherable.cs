using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGatherable
{
    public void Gather(PlayerGathering player);
    public ResourceType GetResourceType();
}
