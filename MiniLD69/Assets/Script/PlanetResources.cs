using UnityEngine;
using System.Collections;

public class PlanetResources : MonoBehaviour {

	PlanetResourceProperties[] resources;

	// Use this for initialization
	void Start () {
		resources = new PlanetResourceProperties[ResourceUtils.NumResourceTypes ()];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
