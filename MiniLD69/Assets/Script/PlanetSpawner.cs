using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

	public GameObject planetPrefab;

	// Use this for initialization
	void Start () {
		SpawnPlanet ( new PlanetSettings() );
	}

	void SpawnPlanet( PlanetSettings planet_settings )
	{
		GameObject go = GameObject.Instantiate(planetPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		PlanetShape rps = go.gameObject.GetComponent<PlanetShape>();
		rps.BuildPlanetTexture (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
