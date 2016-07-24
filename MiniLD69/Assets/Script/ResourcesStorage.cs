using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ResourcesStorage : MonoBehaviour {

	private float[] storage;

	public ResourcesStorage()
	{
		storage = new float[ResourceUtils.NumResourceTypes()];
	}

	public void AddResourceQuantity( ResourceUtils.ResourceType resource_type, float quantity )
	{
		Assert.IsTrue (quantity >= 0);
		storage [(int)resource_type] += quantity;
	}

	public float GetResourceQuantity( ResourceUtils.ResourceType resource_type )
	{
		return storage [(int)resource_type];
	}
}
