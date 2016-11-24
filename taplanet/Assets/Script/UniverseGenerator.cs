using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniverseGenerator : MonoBehaviour {

	public int numberOfPlanets = 10;
	public float scale = 10.0f;
	public int numberOfGenerationRetries = 0;

	public GameObject sun;
	public List<GameObject> planets;

	GameObject planetPrefab;

	// Use this for initialization
	void Awake () {
		planetPrefab = (GameObject) Resources.Load ("Planet");
		planets = new List<GameObject> ();

		float current_pos = 10 + Random.value * 10;
		float first_pos = current_pos;

		LinkedList<PlanetSettings> planet_settings = new LinkedList<PlanetSettings> ();
		while( planet_settings.Count < numberOfPlanets )
		{
			current_pos += 5 + Random.value * 15;
			Vector3 position = new Vector3 (0, current_pos, 0);
			PlanetSettings settings = new PlanetSettings ();
			settings.position = position;
			settings.size = GenerateRandomSize ();
			settings.resourceGatheringRate = GenerateResourceProperties ();
			settings.name = PlanetNameGenerator.GenerateName ();
			planet_settings.AddLast (settings);
		}

		PlanetSettings st = GenerateSun ();
		sun = SpawnPlanet (st);

		foreach( PlanetSettings settings in planet_settings )
		{
			// compute temperature depending on sun power and proximity to sun
			// two params - all blue    |   mid tones   |   all red
			settings.temperature = (settings.position.y - first_pos) / (current_pos - first_pos);
			settings.distanceToSun = settings.position.y - sun.transform.position.y;
			planets.Add(SpawnPlanet (settings));
		}
	}

	PlanetSettings GenerateSun()
	{
		PlanetSettings settings = new PlanetSettings ();
		settings.position = new Vector3 (0, 0, 0);
		settings.size = 20;
		settings.resourceGatheringRate [0] = 1;
		settings.resourceGatheringRate [1] = 1;
		settings.resourceGatheringRate [2] = 1;
		settings.temperature = -1;
		settings.name = PlanetNameGenerator.GenerateName ();
		settings.distanceToSun = 0;
		return settings;
	}

	float[] GenerateResourceProperties()
	{
		float[] resource_properties = new float[ResourceUtils.NumResourceTypes ()];
		for (int i = 0; i < ResourceUtils.NumResourceTypes (); i++) {
			resource_properties [i] = Random.value;
		}
		return resource_properties;
	}

	float GenerateRandomSize()
	{
		return 2 + UnityEngine.Random.value * UnityEngine.Random.value * 8;
	}

	GameObject SpawnPlanet( PlanetSettings planet_settings )
	{
		GameObject go = GameObject.Instantiate(planetPrefab, planet_settings.position, Quaternion.identity) as GameObject;
		Planet planet = go.gameObject.GetComponent<Planet> ();
		planet.BuildGraphics ((int)(Random.value * 1000), planet_settings);
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
