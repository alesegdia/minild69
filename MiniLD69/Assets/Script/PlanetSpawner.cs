using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

	public GameObject planetPrefab;

	// Use this for initialization
	void Start () {
		SpawnPlanet ();
	}

	void SpawnPlanet( )
	{
		GameObject tr = GameObject.Instantiate(planetPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		RandomPlanetShape rps = tr.gameObject.GetComponent<RandomPlanetShape>();
		rps.BuildPlanetGraphics (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
