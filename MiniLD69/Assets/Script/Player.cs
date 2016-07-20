using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public UniverseGenerator universe;
	public CameraController camController;

	void ReachDelegate( Planet p )
	{
		Debug.Log ("ok im ere");
	}

	// Use this for initialization
	void Start () {
		int selected = Random.Range (0, universe.planets.Count - 1);
		Planet p = universe.planets[selected].GetComponent<Planet>();
		camController.GoToPlanet (p, ReachDelegate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
