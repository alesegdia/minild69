using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	enum CamState {
		MovingToPlanet,
		MovingToGlobal,
		Idle
	};

	public delegate void OnReachPlanetDelegate( Planet planet );
	public delegate void OnReachGlobalDelegate();

	public Camera cam;
	public UniverseGenerator universe;

	// generic movement variables
	Vector3 objective;
	float t = 0;

	CamState state = CamState.Idle;

	// gotoplanet variables
	OnReachPlanetDelegate reachPlanetDelegate;
	Planet planet;

	// gotoglobal variables
	OnReachGlobalDelegate reachGlobalDelegate;

	public void GoToPlanet( Planet planet, OnReachPlanetDelegate reach_delegate )
	{
		this.planet = planet;
		this.state = CamState.MovingToPlanet;
		this.objective = planet.transform.position;
		this.objective.z = -2 - planet.settings.size * 2;
		this.reachPlanetDelegate = reach_delegate;
	}

	public void GoToGlobal( OnReachGlobalDelegate reach_delegate )
	{
		this.state = CamState.MovingToGlobal;
		this.objective = new Vector3 (0, 0, -100);
		this.reachGlobalDelegate = reach_delegate;
	}

	bool TryMovement()
	{
		bool did_move = false;
		if (this.cam.transform.position != objective) {
			this.t += Time.deltaTime / 10.0f;
			this.cam.transform.position = Vector3.Lerp (this.cam.transform.position, this.objective, this.t);
			did_move = true;
		}
		return did_move;
	}

	void GoToIdleState()
	{
		this.t = 0;
		this.state = CamState.Idle;
	}

	// Update is called once per frame
	void Update () {
		switch (this.state) {
		case CamState.Idle:
			break;
		case CamState.MovingToPlanet:
			if (false == TryMovement ()) {
				GoToIdleState ();
				this.reachPlanetDelegate (planet);
			}
			break;
		case CamState.MovingToGlobal:
			if (false == TryMovement ()) {
				GoToIdleState ();
				this.reachGlobalDelegate ();
			}
			break;
		}
	}
}
