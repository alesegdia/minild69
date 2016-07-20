using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	enum CamState {
		Moving, Idle
	};

	public delegate void OnReachDelegate( Planet planet );

	public Camera cam;
	public UniverseGenerator universe;

	Vector3 objective;
	float t = 0;
	CamState state = CamState.Idle;
	OnReachDelegate reachDelegate;
	Planet planet;

	public void GoToPlanet( Planet planet, OnReachDelegate reach_delegate )
	{
		this.planet = planet;
		this.state = CamState.Moving;
		this.objective = planet.transform.position;
		this.objective.z = -2;
		this.reachDelegate = reach_delegate;
	}

	// Update is called once per frame
	void Update () {
		switch (this.state) {
		case CamState.Idle:
			break;
		case CamState.Moving:
			if (this.cam.transform.position != objective) {
				this.t += Time.deltaTime / 10.0f;
				this.cam.transform.position = Vector3.Lerp (this.cam.transform.position, this.objective, this.t);
			} else {
				this.t = 0;
				this.state = CamState.Idle;
				this.reachDelegate (planet);
			}
			break;
		}
	}
}
