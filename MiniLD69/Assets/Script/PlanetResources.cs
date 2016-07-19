using UnityEngine;
using System.Collections;

public class PlanetResources : MonoBehaviour {

	PlanetResourceInfo[] resources;

	// Use this for initialization
	void Start () {
		resources = new PlanetResourceInfo[ResourceUtils.NumResourceTypes ()];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
