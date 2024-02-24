using UnityEngine;
using UnityEngine.UI;

public class GunPickUp : MonoBehaviour
{
	public GameObject realGun;

	public GameObject fakeGun;

	public AudioSource Sound;

	public Light light;

	public Text loadedAmmoText;

	public Text remainingAmmoText;

	private void Start()
	{
		loadedAmmoText.enabled = false;
		remainingAmmoText.enabled = false;
		realGun.SetActive(value: false);
	}

	private void OnTriggerEnter(Collider other)
	{
		realGun.SetActive(value: true);
		fakeGun.SetActive(value: false);
		light.enabled = false;
		loadedAmmoText.enabled = true;
		remainingAmmoText.enabled = true;
		Sound.Play();
	}
}
