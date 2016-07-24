using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniverseGenerator : MonoBehaviour {

	public int numberOfPlanets = 10;
	public float scale = 10.0f;
	public int numberOfGenerationRetries = 0;
	public List<GameObject> planets;

	GameObject planetPrefab;

	// Use this for initialization
	void Awake () {
		planetPrefab = (GameObject) Resources.Load ("Planet");
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
			PlanetSettings settings = GeneratePlanetSettingsAtPosition (position);
			planets.Add(SpawnPlanet (settings));
		}
	}

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

	void AppendRandomLetter( ref string str )
	{
		string letters = "qwertyuiopasdfghjklzxcvbnm";
		str += letters [Random.Range (0, letters.Length)];
	}

	void AppendRandomNumber( ref string str )
	{
		string numbers = "1234567890";
		str += numbers [Random.Range (0, numbers.Length)];
	}

	string GenerateName()
	{
		string name = "";
		AppendRandomLetter (ref name);
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		name += "-";
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		name += "-";
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		AppendRandomLetter (ref name);
		return name;
	}

	PlanetSettings GeneratePlanetSettingsAtPosition( Vector3 position )
	{
		PlanetSettings settings = new PlanetSettings ();
		settings.position = position;
		settings.size = GenerateRandomSize ();
		settings.resourceProperties = GenerateResourceProperties ();
		settings.name = GenerateName ();
		return settings;
	}

	public GameObject SpawnPlanet( PlanetSettings planet_settings )
	{
		GameObject go = GameObject.Instantiate(planetPrefab, planet_settings.position, Quaternion.identity) as GameObject;
		Planet planet = go.gameObject.GetComponent<Planet> ();
		planet.BuildPlanetTexture ((int)(Random.value * 1000), planet_settings);
		go.transform.localScale = new Vector3(planet_settings.size, planet_settings.size, planet_settings.size);
		planet.settings = planet_settings;
		return go;
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
