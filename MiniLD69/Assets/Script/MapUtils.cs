using UnityEngine;
using System.Collections;

public class MapUtils {

	public static void CopyMatrixToTexture( float[][] map, Texture2D texture )
	{
		for (int i = 0; i < map.Length; i++) {
			for (int j = 0; j < map[0].Length; j++) {
				texture.SetPixel (i, j, new Color(map[i][j], map[i][j], map[i][j]));
			}
		}
		texture.Apply ();
	}

}
