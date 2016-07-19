using System.Collections;
using System.Linq;
using System;

public class ResourceUtils {
	public enum ResourceType : int {
		Froncetite = 0, Sandetite
	}

	public static int NumResourceTypes()
	{
		return (int) Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().Max();
	}
}
