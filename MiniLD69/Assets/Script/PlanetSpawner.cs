using UnityEngine;
using System.Collections;

public class PlanetSpawner {

	GameObject planetPrefab;

	public PlanetSpawner()
	{
		planetPrefab = (GameObject) Resources.Load ("Planet");
	}

	public GameObject SpawnPlanet( PlanetSettings planet_settings )
	{
		GameObject go = GameObject.Instantiate(planetPrefab, planet_settings.position, Quaternion.identity) as GameObject;
		PlanetShape rps = go.gameObject.GetComponent<PlanetShape>();
		rps.BuildPlanetTexture ((int)(Random.value * 1000));
		go.transform.localScale = new Vector3(planet_settings.size, planet_settings.size, planet_settings.size);
		Planet planet = go.gameObject.GetComponent<Planet> ();
		planet.settings = planet_settings;
		return go;
	}
}
