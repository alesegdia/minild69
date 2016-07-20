using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniverseGenerator : MonoBehaviour {

	public int numberOfPlanets = 20;
	public float scale = 50.0f;
	public int numberOfGenerationRetries = 0;
	public List<GameObject> planets;

	PlanetSpawner planetSpawner;

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
			PlanetSettings settings = new PlanetSettings ();
			settings.position = position;
			planets.Add(planetSpawner.SpawnPlanet (settings));
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
