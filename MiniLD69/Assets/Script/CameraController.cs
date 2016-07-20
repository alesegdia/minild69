using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera cam;
	public UniverseGenerator universe;

	Vector3 objective;
	float t = 0;

	enum CamState {
		Moving, Idle
	};

	CamState state = CamState.Idle;

	OnReachDelegate reachDelegate;
	Planet planet;

	public delegate void OnReachDelegate( Planet planet );

	public void GoToPlanet( Planet planet, OnReachDelegate reach_delegate )
	{
		this.planet = planet;
		this.state = CamState.Moving;
		this.objective = planet.transform.position;
		this.objective.z = -2;
		this.reachDelegate = reach_delegate;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case CamState.Idle:
			break;
		case CamState.Moving:
			if (cam.transform.position != objective) {
				t += Time.deltaTime / 10.0f;
				cam.transform.position = Vector3.Lerp (cam.transform.position, objective, t);
			} else {
				t = 0;
				state = CamState.Idle;
				reachDelegate (planet);
			}
			break;
		}
	}
}
