using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	enum GameState {
		StartSelectPlanet,
		OnPlanetView
	};

	public UniverseGenerator universe;
	public CameraController camController;

	GameObject planetView;
	GameObject startGameView;

	GameState state;

	void reachGlobalDelegate( )
	{
		Debug.Log ("ok im in global");
	}

	// Use this for initialization
	void Start () {
		state = GameState.StartSelectPlanet;
		this.camController.GoToGlobal ( reachGlobalDelegate );
		planetView = GameObject.Find ("/InGameViews/PlanetView");
		startGameView = GameObject.Find ("/InGameViews/StartGameView");
		planetView.SetActive (false);
	}

	void ChooseStartingPlanet( Planet starting_planet )
	{
		state = GameState.OnPlanetView;
		startGameView.SetActive (false);
		CameraController.OnReachPlanetDelegate on_reach_planet_delegate = planet => {
			planetView.SetActive (true);
		};
		this.camController.GoToPlanet (starting_planet, on_reach_planet_delegate);
	}

	void FixedUpdate () {
		switch (state) {
		case GameState.StartSelectPlanet:
			if (true == Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (true == Physics.Raycast (ray, out hit)) {
					Planet starting_planet = hit.collider.gameObject.GetComponent<Planet> ();
					ChooseStartingPlanet (starting_planet);
				}
			}
			break;
		}
	}

}
