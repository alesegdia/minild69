using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {

	public GUIStyle style;
	public Player player;

	enum GameState {
		StartSelectPlanet,
		OnPlanetView
	};

	GameState state;

	// Use this for initialization
	void Start () {
		state = GameState.StartSelectPlanet;
	}
	
	void FixedUpdate () {
		switch (state) {
		case GameState.StartSelectPlanet:
			if (true == Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (true == Physics.Raycast (ray, out hit)) {
					Planet starting_planet = hit.collider.gameObject.GetComponent<Planet> ();
					player.FirstPlanetChosen (starting_planet);
					state = GameState.OnPlanetView;
				}
			}
			break;
		}
	}

	void OnGUI () {
		switch (state) {
		case GameState.StartSelectPlanet:
			GUI.Label (new Rect (10, 10, 100, 20), "Choose a starting planet", style);
			break;
		case GameState.OnPlanetView:
			break;
		}
	}
}
