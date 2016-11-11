using UnityEngine;
using System.Collections;

public class PlanetSettings {
	public Vector3 position { get; set; }
	public int seed { get; set; }
	public float temperature { get; set; }
	public float size { get; set; }
	public float[] resourceGatheringRate { get; set; }
	public string name { get; set; }
}
