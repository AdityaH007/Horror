using UnityEngine;

public class AmmoPick : MonoBehaviour
{
	public GameObject fakeAmmo;

	public int ammoAmount = 10;

	public Light light;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<AmmoController>().AddAmmo(ammoAmount);
			fakeAmmo.SetActive(value: false);
			light.enabled = false;
		}
	}
}
