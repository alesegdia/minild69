using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera cam;
	public UniverseGenerator universe;

	Vector3 objective;
	float t = 0;

	// Use this for initialization
	void Start () {
		int selected = Random.Range (0, universe.planets.Count - 1);
		objective = universe.planets[selected].transform.position;
		objective.z = -2;
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.transform.position != objective) {
			t += Time.deltaTime / 10.0f;
			cam.transform.position = Vector3.Lerp (cam.transform.position, objective, t);
		} else {
			t = 0;
		}
	}
}
