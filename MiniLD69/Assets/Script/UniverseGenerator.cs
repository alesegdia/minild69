using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniverseGenerator : MonoBehaviour {

	public int numberOfPlanets = 10;
	public float scale = 10.0f;
	public int numberOfGenerationRetries = 0;
	public List<GameObject> planets;

	PlanetSpawner planetSpawner;

	PlanetResourceProperties[] GenerateResourceProperties()
	{
		PlanetResourceProperties[] resource_properties = new PlanetResourceProperties[ResourceUtils.NumResourceTypes()];
		for (int i = 0; i < ResourceUtils.NumResourceTypes (); i++) {
			resource_properties [i] = new PlanetResourceProperties ();
			resource_properties [i].baseGatheringRate = Random.value;
		}
		return resource_properties;
	}

	float GenerateRandomSize()
	{
		return 2 + UnityEngine.Random.value * UnityEngine.Random.value * 8;
	}

	PlanetSettings GeneratePlanetSettingsAtPosition( Vector3 position )
	{
		PlanetSettings settings = new PlanetSettings ();
		settings.position = position;
		settings.size = GenerateRandomSize ();
		settings.resourceProperties = GenerateResourceProperties ();
		return settings;
	}

	// Use this for initialization
	void Awake () {
		planetSpawner = new PlanetSpawner ();
		planets = new List<GameObject> ();

		List<Vector3> positions = new List<Vector3> ();

		while (positions.Count < numberOfPlanets) {
			int num_retries = 0;
			for (int i = 0; i < numberOfPlanets; i++) {
				Vector2 position = UnityEngine.Random.insideUnitCircle;
				position.Scale (new Vector2 (scale, scale));
				if (positionAlreadyTaken (position, positions)) {
					num_retries++;
					if (num_retries > numberOfGenerationRetries) {
						positions.Clear ();
						break;
					} else {
						i--;
					}
				} else {
					positions.Add (new Vector3(position.x, position.y, 0));
					num_retries = 0;
				}
			}
		}
		foreach (Vector3 position in positions) {
			planets.Add(planetSpawner.SpawnPlanet (GeneratePlanetSettingsAtPosition (position)));
		}
	}

	bool positionAlreadyTaken(Vector3 position, List<Vector3> positions)
	{
		foreach( Vector3 other_position in positions )
		{
			Vector3 sep = position - other_position;
			if (sep.magnitude < scale * 4 / numberOfPlanets) {
				return true;
			}
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
