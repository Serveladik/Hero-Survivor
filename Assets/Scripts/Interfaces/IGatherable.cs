using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGatherable
{
    public void Gather(Player player);
    public ResourceType GetResourceType();
}
