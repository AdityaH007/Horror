using UnityEngine;

public class SprayController : MonoBehaviour
{
	public GameObject sprayPrefab;

	public Transform sprayPoint;

	public LayerMask sprayLayer;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Spray();
		}
	}

	private void Spray()
	{
		if (Physics.Raycast(sprayPoint.position, sprayPoint.forward, out var hitInfo, float.PositiveInfinity, sprayLayer))
		{
			Vector3 position = hitInfo.point + hitInfo.normal * 0.1f;
			Object.Instantiate(sprayPrefab, position, Quaternion.LookRotation(hitInfo.normal)).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			MarkWall(position, hitInfo.normal);
		}
	}

	private void MarkWall(Vector3 position, Vector3 normal)
	{
		Object.Destroy(Object.Instantiate(sprayPrefab, position, Quaternion.LookRotation(normal)), 10f);
		Vector3 vector = position;
		Debug.Log("SprayPrefab instantiated at " + vector.ToString() + " and destroyed after 10 seconds.");
	}
}
