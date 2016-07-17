using UnityEngine;
using System.Collections;

public class RandomPlanetShape : MonoBehaviour {

	public MeshFilter mesh;
	Texture2D texture;

	// Use this for initialization
	void Start () {
		Debug.Log ("meh");
		texture = new Texture2D (100, 100);
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 100; j++) {
				texture.SetPixel (i, j, Color.red);
			}
		}
		texture.Apply ();
		mesh.GetComponent<MeshRenderer> ().material.SetTexture("_MainTex", texture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
