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
		rps.BuildPlanetTexture (0);
		return go;
	}
}
