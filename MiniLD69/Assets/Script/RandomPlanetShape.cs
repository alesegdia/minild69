﻿using UnityEngine;
using System.Collections;

public class RandomPlanetShape : MonoBehaviour {

	public MeshFilter mesh;
	Texture2D texture;

	// Use this for initialization
	void Start () {
		BuildPlanetGraphics (4);
	}

	void BuildPlanetGraphics( int seed )
	{
		float[][] map = NoiseUtils.GeneratePerlinNoise (100, 100, 4, seed);
		texture = new Texture2D (100, 100);
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 100; j++) {
				texture.SetPixel (i, j, new Color(map[i][j], map[i][j], map[i][j]));
			}
		}
		texture.Apply ();
		mesh.GetComponent<MeshRenderer> ().material.SetTexture("_MainTex", texture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
