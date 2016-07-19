using UnityEngine;
using System.Collections;

public class PlanetShape : MonoBehaviour {

	MeshRenderer meshRenderer;
	Texture2D texture;

	// Use this for initialization
	void Awake () {
		meshRenderer = GetComponent<MeshRenderer> ();
		texture = new Texture2D (100, 100);
		meshRenderer.material.SetTexture("_MainTex", texture);
	}

	public void BuildPlanetTexture( int seed )
	{
		float[][] map = NoiseUtils.GeneratePerlinNoise (100, 100, 4, seed);
		MapUtils.CopyMatrixToTexture (map, texture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
