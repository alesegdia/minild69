using UnityEngine;
using System.Collections;

public class PlanetResources : MonoBehaviour {

	PlanetResourceProperties[] resourcesProps;
	ResourcesStorage planetResourcesStorage;

	// Use this for initialization
	void Start () {
		resourcesProps = new PlanetResourceProperties[ResourceUtils.NumResourceTypes ()];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
