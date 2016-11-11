using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public PlanetSettings settings;
	public PlanetBuildings buildings;
	public ResourcesStorage planetStorage;

	MeshRenderer meshRenderer;
	Texture2D texture;
	int textureSize = 200;

	// Use this for initialization
	void Awake () {
		planetStorage = new ResourcesStorage ();
		meshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0, 0.4f, 0));
	}

	public void GatherManualResources()
	{
		for (int i = 0; i < ResourceUtils.NumResourceTypes (); i++) {
			planetStorage.AddResourceQuantity((ResourceUtils.ResourceType)i, settings.resourceGatheringRate [i] * 2);
		}
	}

	public void BuildGraphics( int seed, PlanetSettings settings )
	{
		texture = new Texture2D (textureSize, textureSize);
		texture.filterMode = FilterMode.Point;
		meshRenderer.material.SetTexture("_MainTex", texture);

		float[][] map = NoiseUtils.GeneratePerlinNoise (textureSize, textureSize, 6, seed);
		MapUtils.CopyMatrixToTexture (map, texture);
		float r, g, b;
		// r = Random.value; g = Random.value; b = Random.value;
		r = settings.resourceGatheringRate[0];
		b = settings.resourceGatheringRate[1];
		g = settings.resourceGatheringRate[2];
		MapUtils.ColourGradient (map, texture,
			new Color[] { new Color(r, g, b), new Color(3.0f * r/4.0f, 3.0f * g/4.0f, 3.0f * b/4.0f), new Color(2.0f * r/4.0f, 2.0f * g/4.0f, 2.0f * b/4.0f), new Color(r/4.0f, g/4.0f, b/4.0f) },
			new float[] { 0.25f, 0.5f, 0.6f, 1.0f });
	}

}
