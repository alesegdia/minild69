using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingShopEntry : MonoBehaviour {

	Text froncetiteCostText;
	Text sandetiteCostText;
	Text xargonCostText;
	Text itemName;
	Text itemDesc;

	void Awake() {
		froncetiteCostText = transform.Find ("FroncetiteCostIndicator/ResourceCost").gameObject.GetComponent<Text> ();
		sandetiteCostText = transform.Find ("SandetiteCostIndicator/ResourceCost").gameObject.GetComponent<Text> ();
		xargonCostText = transform.Find ("XargonCostIndicator/ResourceCost").gameObject.GetComponent<Text> ();
		itemName = transform.Find ("ItemName_Text").gameObject.GetComponent<Text> ();
		itemDesc = transform.Find ("ItemDescription_Text").gameObject.GetComponent<Text> ();
	}

	public void SetCosts(BaseCosts costs) {
		froncetiteCostText.text = costs.froncetiteCost.ToString();
		sandetiteCostText.text = costs.sandetiteCost.ToString();
		xargonCostText.text = costs.xargonCost.ToString();
	}

	public void SetInfo( string name, string description ) {
		itemName.text = name;
		itemDesc.text = description;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
