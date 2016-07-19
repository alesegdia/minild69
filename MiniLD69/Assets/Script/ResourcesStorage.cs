using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ResourcesStorage : MonoBehaviour {

	private float[] storage;

	public ResourcesStorage()
	{
		storage = new float[ResourceUtils.NumResourceTypes()];
	}

	public void addResourceQuantity( ResourceUtils.ResourceType resource_type, float quantity )
	{
		Assert.IsTrue (quantity >= 0);
		storage [resource_type] += quantity;
	}

}
