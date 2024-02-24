using System.Collections;
using UnityEngine;

public class GunSpray : MonoBehaviour
{
	public GameObject sprayPrefab;

	public GameObject gun;

	public Transform sprayPoint;

	public LayerMask sprayLayer;

	public AmmoController ammoController;

	private bool isSpraying;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !isSpraying)
		{
			Spray();
		}
	}

	private void Spray()
	{
		isSpraying = true;
		if (Physics.Raycast(sprayPoint.position, sprayPoint.forward, out var hitInfo, float.PositiveInfinity, sprayLayer) && gun.activeSelf && ammoController.loadedAmmo > 1)
		{
			Vector3 position = hitInfo.point + hitInfo.normal * 0.1f;
			if (sprayPrefab != null)
			{
				GameObject gameObject = Object.Instantiate(sprayPrefab, position, Quaternion.LookRotation(hitInfo.normal));
				gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				MarkWall(position, hitInfo.normal, gameObject);
			}
		}
		StartCoroutine(ResetSprayingFlag());
	}

	private IEnumerator ResetSprayingFlag()
	{
		yield return new WaitForSeconds(0.1f);
		isSpraying = false;
	}

	private void MarkWall(Vector3 position, Vector3 normal, GameObject sprayEffect)
	{
		Object.Destroy(sprayEffect, 0.5f);
		Vector3 vector = position;
		Debug.Log("SprayPrefab instantiated at " + vector.ToString() + " and destroyed after 1 second.");
	}
}
