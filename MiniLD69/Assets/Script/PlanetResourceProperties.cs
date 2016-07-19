using UnityEngine;
using System.Collections;

/// <summary>
/// Planet resource info. Represents which properties a planet has for a specific resource type
/// </summary>
public class PlanetResourceInfo {
	public float baseGatheringRate { get; set; }
	public ResourceUtils.ResourceType resourceType { get; set; }
}
