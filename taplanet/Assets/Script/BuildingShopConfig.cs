using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BaseCosts {
	public int froncetiteCost;
	public int sandetiteCost;
	public int xargonCost;
}

[System.Serializable]
public struct BuildingShopEntryData {
	[HeaderAttribute("Basic Info")]

	public int ID;
	public string name;
	public BaseCosts baseCosts;

	[HeaderAttribute("Player Info")]
	public int currentUnitsInPlanet;

	[TextAreaAttribute]
	public string description;

	[HeaderAttribute("Unlock Info")]
	public int upgradeID;
}

public class BuildingShopConfig : MonoBehaviour {

	public BuildingShopEntryData[] entries;
	GameObject buildingShopEntryPrefab;
	GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Scroll View/Viewport/Content");
		buildingShopEntryPrefab = Resources.Load ("ShopItemEntry") as GameObject;
		LoadPlanetBuildings (null);
	}

	RectTransform rtt;

	public void LoadPlanetBuildings( Planet planet )
	{
		int i = 0;
		RectTransform rt = canvas.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2 (rt.sizeDelta.x, entries.Length * 253);
		foreach( BuildingShopEntryData entry in entries )
		{
			GameObject go = GameObject.Instantiate (buildingShopEntryPrefab);
			BuildingShopEntry goEntry = go.GetComponent<BuildingShopEntry>() as BuildingShopEntry;
			goEntry.SetInfo (entry.name, entry.description);
			goEntry.SetCosts (entry.baseCosts);
			goEntry.transform.SetParent (canvas.transform);
			goEntry.transform.localScale = new Vector3 (1, 1, 1);
			//go.transform.localPosition = new Vector3 (100, -160 - 250 * i, 0);
			RectTransform mrt = go.GetComponent<RectTransform>();
			mrt.anchorMin = new Vector2 (0.5f, 1);
			mrt.anchorMax = new Vector2 (0.5f, 1);
			mrt.localPosition = new Vector3 (98.57298f, -130 - 250 * i, 0);
			rtt = rt;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
