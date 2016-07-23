using UnityEngine;
using System.Collections;

public class PlanetShape : MonoBehaviour {

	MeshRenderer meshRenderer;
	Texture2D texture;
	int textureSize = 400;

	// Use this for initialization
	void Awake () {
		meshRenderer = GetComponent<MeshRenderer> ();
		texture = new Texture2D (textureSize, textureSize);
		texture.filterMode = FilterMode.Bilinear;
		meshRenderer.material.SetTexture("_MainTex", texture);
	}

	public void BuildPlanetTexture( int seed )
	{
		float[][] map = NoiseUtils.GeneratePerlinNoise (textureSize, textureSize, 6, seed);
		MapUtils.CopyMatrixToTexture (map, texture);
		float r, g, b;
		r = Random.value; g = Random.value; b = Random.value;
		MapUtils.ColourGradient (map, texture,
			new Color[] { new Color(r, g, b), new Color(3.0f * r/4.0f, 3.0f * g/4.0f, 3.0f * b/4.0f), new Color(2.0f * r/4.0f, 2.0f * g/4.0f, 2.0f * b/4.0f), new Color(r/4.0f, g/4.0f, b/4.0f) },
			new float[] { 0.25f, 0.5f, 0.6f, 1.0f });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
