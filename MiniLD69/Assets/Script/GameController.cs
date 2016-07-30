using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameController : MonoBehaviour {

	enum GameState {
		StartSelectPlanet,
		OnPlanetView,
		OnUniverseView,
	};

	GameState state;

	public UniverseGenerator universe;
	public CameraController camController;

	GameObject planetView;
	GameObject startGameView;
	GameObject shoppingView;
	GameObject bottomView;

	Planet currentPlanet;
	ResourcesStorage playerResourcesStorage;


	// Use this for initialization
	void Start () {
		state = GameState.StartSelectPlanet;
		this.camController.GoToGlobal ( reachGlobalDelegate );
		playerResourcesStorage = new ResourcesStorage ();
		planetView = GameObject.Find ("/InGameViews/PlanetView");
		startGameView = GameObject.Find ("/InGameViews/StartGameView");
		shoppingView = GameObject.Find ("/InGameViews/BuidlingShopView");
		bottomView = GameObject.Find ("/InGameViews/BottomView");

		// setup planet view buttons
		bottomView.transform.Find ("Buttons/BackIcon").GetComponent<Button> ().onClick.AddListener (GoToGlobalEventResponse);
		bottomView.transform.Find ("Buttons/BuildingsIcon").GetComponent<Button> ().onClick.AddListener (GoToBuildingsShop);
		planetView.transform.Find ("TransferIcon").GetComponent<Button> ().onClick.AddListener (TransferResourcesToPlayer);

		// turn off all but start game view
		planetView.SetActive (false);
		shoppingView.SetActive (false);
		bottomView.SetActive (false);
	}

	void reachGlobalDelegate( )
	{
		Debug.Log ("ok im in global");
	}

	public void GoToGlobalEventResponse()
	{
		planetView.SetActive (false);
		camController.GoToGlobal (reachGlobalDelegate);
		state = GameState.OnUniverseView;
	}

	public void GoToBuildingsShop()
	{
		shoppingView.SetActive (true);
		planetView.SetActive (false);
	}

	public void TransferResourcesToPlayer()
	{
		currentPlanet.planetStorage.TransferTo (ref playerResourcesStorage);
	}

	void ReachPlanetDelegate( Planet planet )
	{
		planetView.SetActive (true);
		planetView.transform.Find("PlanetName").GetComponent<Text>().text = planet.settings.name;
	}

	void ReachFirstPlanetDelegate( Planet planet )
	{
		bottomView.SetActive (true);
		ReachPlanetDelegate (planet);
	}

	void ChooseStartingPlanet( Planet starting_planet )
	{
		state = GameState.OnPlanetView;
		startGameView.SetActive (false);
		this.camController.GoToPlanet (starting_planet, ReachFirstPlanetDelegate);
		currentPlanet = starting_planet;
	}

	void Update () {
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
		case GameState.OnPlanetView:
			UpdatePlanetResourceMarkers ();
			UpdatePlayerResourceMarkers ();
			if (true == Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (true == Physics.Raycast (ray, out hit)) {
					Planet p = hit.collider.gameObject.GetComponent<Planet> ();
					if (p != null) {
						p.GatherManualResources ();
					}
				}
			}
			break;
		}
	}

	void UpdatePlanetResourceMarkers()
	{
		GameObject planet_resource_markers = planetView.transform.Find ("PlanetResourceMarkers").gameObject;
		UpdateResourceMarkers (planet_resource_markers, currentPlanet.planetStorage);
	}

	void UpdatePlayerResourceMarkers()
	{
		GameObject player_resource_markers = planetView.transform.Find ("PlayerResourceMarkers").gameObject;
		UpdateResourceMarkers (player_resource_markers, playerResourcesStorage);
	}

	void UpdateResourceMarkers( GameObject resource_markers, ResourcesStorage storage )
	{
		Text f_text = resource_markers.transform.Find ("FroncetiteQuantity_Text").GetComponent<Text> ();
		Text s_text = resource_markers.transform.Find ("SandetiteQuantity_Text").GetComponent<Text> ();
		Text x_text = resource_markers.transform.Find ("XargonQuantity_Text").GetComponent<Text> ();
		f_text.text = ((int)Mathf.Round (storage.GetResourceQuantity (ResourceUtils.ResourceType.Froncetite))).ToString();
		s_text.text = ((int)Mathf.Round (storage.GetResourceQuantity (ResourceUtils.ResourceType.Sandetite))).ToString();
		x_text.text = ((int)Mathf.Round (storage.GetResourceQuantity (ResourceUtils.ResourceType.Xargon))).ToString();
	}

}
