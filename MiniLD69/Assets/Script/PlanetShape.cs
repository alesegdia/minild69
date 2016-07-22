using UnityEngine;
using System.Collections;

public class PlanetShape : MonoBehaviour {

	MeshRenderer meshRenderer;
	Texture2D texture;
	int textureSize = 200;

	// Use this for initialization
	void Awake () {
		meshRenderer = GetComponent<MeshRenderer> ();
		texture = new Texture2D (textureSize, textureSize);
		texture.filterMode = FilterMode.Point;
		meshRenderer.material.SetTexture("_MainTex", texture);
	}

	public void BuildPlanetTexture( int seed )
	{
		float[][] map = NoiseUtils.GeneratePerlinNoise (textureSize, textureSize, 6, seed);
		MapUtils.CopyMatrixToTexture (map, texture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
