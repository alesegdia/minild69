using UnityEngine;
using System.Collections;

public class PlanetNameGenerator {

	private static void AppendRandomLetter( ref string str )
	{
		string letters = "QWERTYUIOPASDFGHJKLZXCVBNM";
		str += letters [Random.Range (0, letters.Length)];
	}

	private static void AppendRandomNumber( ref string str )
	{
		string numbers = "1234567890";
		str += numbers [Random.Range (0, numbers.Length)];
	}

	public static string GenerateName()
	{
		string name = "";
		AppendRandomLetter (ref name);
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		name += "-";
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		name += "-";
		AppendRandomLetter (ref name);
		AppendRandomNumber (ref name);
		AppendRandomLetter (ref name);
		return name;
	}

}
