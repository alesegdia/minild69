using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ResourcesStorage {

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

	public void TransferTo( ref ResourcesStorage other_storage )
	{
		for (int i = 0; i < ResourceUtils.NumResourceTypes (); i++) {
			other_storage.storage [i] += storage [i];
			storage [i] = 0;
		}
	}
}
